package rsreu;

import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.concurrent.*;
import java.util.concurrent.atomic.AtomicInteger;


public class MySemaphoreTest {

    @Test
    public void testOne() throws InterruptedException, ExecutionException {
        MySemaphore semaphore = new MySemaphore(1);
        CountDownLatch countDownLatch = new CountDownLatch(1);
        AtomicInteger atomicInteger = new AtomicInteger(0);

        ExecutorService executorService = Executors.newFixedThreadPool(2);
        Callable<Boolean> firstTask = new SemaphoreTaskOne(semaphore, countDownLatch, atomicInteger);
        Callable<Boolean> secondTask = new SemaphoreTaskTwo(semaphore, countDownLatch, atomicInteger);

        Future<Boolean> futureOne = executorService.submit(firstTask);
        Future<Boolean> futureTwo = executorService.submit(secondTask);

        Assert.assertTrue(futureOne.get());
        Assert.assertTrue(futureTwo.get());

        executorService.shutdown();
    }

    @Test
    public void testTwo() {
        MySemaphore semaphore = new MySemaphore(3);
        ExecutorService executorService = Executors.newFixedThreadPool(250);

        Callable<Boolean> task = new SemaphoreTaskThree(semaphore, 3);
        ArrayList<Future<Boolean>> futures = new ArrayList<>();

        for (int i = 0; i < 500; i++) {
            futures.add(executorService.submit(task));
        }

        for (Future<Boolean> future : futures) {
            try {
                Assert.assertTrue(future.get());
            } catch (InterruptedException | ExecutionException | CancellationException e) {
                System.out.println(e.getMessage());
            }
        }
        executorService.shutdown();
    }

    @Test
    public void testThree() {
        MySemaphore semaphore = new MySemaphore(3);
        ExecutorService executorService = Executors.newFixedThreadPool(8);

        Callable<Boolean> task = new SemaphoreTaskThree(semaphore, 3);
        ArrayList<Future<Boolean>> futures = new ArrayList<>();

        for (int i = 0; i < 8; i++) {
            futures.add(executorService.submit(task));
        }

        for (Future<Boolean> future : futures) {
            try {
                Assert.assertTrue(future.get());
            } catch (InterruptedException | ExecutionException | CancellationException e) {
                System.out.println(e.getMessage());
            }
        }
        executorService.shutdown();
    }

}
