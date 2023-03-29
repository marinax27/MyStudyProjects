package rsreu;

import java.util.List;
import java.util.concurrent.Future;

public class Progress<T> implements Runnable {
    private List<Future<T>> futures;

    public Progress(List<Future<T>> futures) {
        this.futures = futures;
    }

    @Override
    public void run() {
        int counter = 0;
        while (counter != futures.size()) {
            int oldCount = counter * 100 / futures.size() / 10;
            counter = 0;
            for (int i = 0; i < futures.size(); i ++) {
                if (futures.get(i).isDone()) {
                    counter++;
                }
            }
            int newCount = counter * 100 / futures.size() / 10;
            if (newCount != oldCount) {
                System.out.println("Прогресс - " + newCount * 10 + "%");
            }

        }
    }

    public List<Future<T>> getFutures() {
        return futures;
    }

    public void setFutures(List<Future<T>> futures) {
        this.futures = futures;
    }
}
