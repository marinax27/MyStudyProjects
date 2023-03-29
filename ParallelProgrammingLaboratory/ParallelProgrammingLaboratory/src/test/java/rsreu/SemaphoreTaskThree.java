package rsreu;

import java.util.concurrent.Callable;
import java.util.concurrent.ThreadLocalRandom;
import java.util.concurrent.atomic.AtomicInteger;

public class SemaphoreTaskThree implements Callable<Boolean> {
    MySemaphore mySemaphore;
    AtomicInteger atomicInteger = new AtomicInteger(0);
    int permits;

    public SemaphoreTaskThree (MySemaphore mySemaphore, int permits) {
        this.mySemaphore = mySemaphore;
        this.permits = permits;
    }

    @Override
    public Boolean call() {
        int result;
        try {
            mySemaphore.acquire();
        } catch (InterruptedException e) {
            System.out.println(e.getMessage());
        }

        try {
            if (atomicInteger.incrementAndGet() > permits) {
                return false;
            }
            System.out.println(Thread.currentThread().getName() + " начал работать!");
            Thread.sleep(ThreadLocalRandom.current().nextInt(10, 200));
            System.out.println(Thread.currentThread().getName() + " закончил работать!");
        } catch (InterruptedException e) {
            System.out.println(e.getMessage());
        } finally {
            result = atomicInteger.decrementAndGet();
            mySemaphore.release();
        }
        return result >= 0;
    }
}
