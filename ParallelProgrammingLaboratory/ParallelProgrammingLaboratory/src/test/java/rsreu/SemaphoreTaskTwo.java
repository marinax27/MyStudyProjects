package rsreu;

import java.util.concurrent.Callable;
import java.util.concurrent.CountDownLatch;
import java.util.concurrent.atomic.AtomicInteger;

public class SemaphoreTaskTwo implements Callable {
    private AtomicInteger atomicInteger;
    MySemaphore mySemaphore;
    CountDownLatch countDownLatch;

    public SemaphoreTaskTwo(MySemaphore mySemaphore, CountDownLatch countDownLatch, AtomicInteger atomicInteger) {
        this.mySemaphore = mySemaphore;
        this.countDownLatch = countDownLatch;
        this.atomicInteger = atomicInteger;
    }

    @Override
    public Boolean call() {
        boolean flag = false;
        try {
            countDownLatch.await();
            mySemaphore.acquire();

            System.out.println(Thread.currentThread().getName() + " получил доступ и начал работать!");
            atomicInteger.getAndSet(2);
            Thread.sleep(2000);
            if (atomicInteger.get() == 2) {
                flag = true;
            }

            System.out.println(Thread.currentThread().getName() + " закончил работать!");

            mySemaphore.release();
        } catch (InterruptedException e) {
            System.out.println("Поток был прерван!");
        }
        return flag;
    }
}
