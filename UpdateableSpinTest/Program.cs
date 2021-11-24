using System.Diagnostics;
using NUnit.Framework;

namespace UpdateableSpinTest
{
    [TestFixture]
    public class UpdateableSpinTest
    {
        [Test]
        public void Wait_NoPulse_ReturnsFalse()
        {
            var spin = new UpdateableSpin();
            var wasPulsed = spin.Wait(TimeSpan.FromMilliseconds(10));
            Assert.IsFalse(wasPulsed);
        }

        [Test]
        public void Wait_Pulse_ReturnsTrue()
        {
            var spin = new UpdateableSpin();

            Task.Factory.StartNew(() => {
                Thread.Sleep(100);
                spin.Set();
            });
            
            var wasPulsed = spin.Wait(TimeSpan.FromSeconds(10));
            Assert.IsTrue(wasPulsed);
        }

        [Test]
        public void Wait50Milliseconds_ActuallyWaitingFor50Milliseconds()
        {
            var spin = new UpdateableSpin();
            var watcher = new Stopwatch();
            
            watcher.Start();
            spin.Wait(TimeSpan.FromMilliseconds(50));
            watcher.Stop();

            var actual = TimeSpan.FromMilliseconds(watcher.ElapsedMilliseconds);
            var leftEpsilon = TimeSpan.FromMilliseconds(50 - (50 * 0.1));
            var rightEpsilon = TimeSpan.FromMilliseconds(50 + (50 * 0.1));

            Assert.IsTrue(actual > leftEpsilon && actual < rightEpsilon);
        }

        [Test]
        public void Wait50Milliseconds_UpdateAfter300Milliseconds_TotalWaitingIsApproximately800Milliseconds()
        {
            var spin = new UpdateableSpin();
            var watcher = new Stopwatch();
            const int timeout = 500;
            const int spanBeforeUpdate = 300;
            const int expected = timeout + spanBeforeUpdate;
            var left = TimeSpan.FromMilliseconds(expected - (expected * 0.1));
            var right = TimeSpan.FromMilliseconds(expected + (expected * 0.1));
            
            Task.Factory.StartNew(() => {
                Thread.Sleep(spanBeforeUpdate);
                spin.UpdateTimeout();
            });

            watcher.Start();
            spin.Wait(TimeSpan.FromMilliseconds(timeout));
            watcher.Stop();

            var actual = TimeSpan.FromMilliseconds(watcher.ElapsedMilliseconds);
            
            Assert.IsTrue(actual > left && actual < right);
        }
    }

    public class UpdateableSpin
    {
        private readonly object lockObj = new Object();
        private bool shouldWait = true;
        private long executionStartingTime;

        public bool Wait(TimeSpan timeout, int spinDuration = 0) {
            UpdateTimeout();
            while (true) {
                lock (lockObj) {
                    if (!shouldWait)
                        return true;
                    if (DateTime.UtcNow.Ticks - executionStartingTime > timeout.Ticks)
                        return false;
                }
                
            Thread.Sleep(spinDuration);
            }
        }

        public void Set()
        {
            lock (lockObj) {
                shouldWait = false;
            }
        }

        public void UpdateTimeout()
        {
            lock (lockObj) {
                executionStartingTime = DateTime.UtcNow.Ticks;
            }
        }
    }
}