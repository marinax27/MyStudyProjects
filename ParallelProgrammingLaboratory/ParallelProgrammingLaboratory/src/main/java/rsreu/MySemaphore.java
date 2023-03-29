package rsreu;

public class MySemaphore {
    private int permits;
    private static final Object LOCK = new Object();

    public MySemaphore(int permits) {
        this.permits = permits;
    }

    public void acquire() throws InterruptedException {
        synchronized (LOCK) {
             while (permits <= 0) {
                 LOCK.wait();
             }
             permits--;
        }
    }

    public boolean tryAcquire() {
        synchronized (LOCK) {
            if (permits > 0) {
                permits--;
                return true;
            }
            return false;
        }
    }

    public void release() {
        synchronized (LOCK) {
            permits++;
            LOCK.notify();
        }
    }
}
