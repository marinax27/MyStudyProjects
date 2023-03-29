package rsreu;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Runner {

    private Runner() {

    }

    public static void main(String[] args) {
        int counter = 1;

        List<Thread> threads = new ArrayList<Thread>();

        while (true) {
            Scanner in = new Scanner(System.in);
            String inputCommand = in.nextLine();
            String[] command = inputCommand.split(" ");
            if (command.length == 2) {
                try {
                    int number = Integer.parseInt(command[1]);
                    switch (command[0]) {
                        case "start":
                            counter = startCommand(counter, threads, number);
                            break;
                        case "stop":
                            stopCommand(threads, number);
                            break;
                        case "await":
                            try {
                                awaitCommand(threads, number);
                            } catch (InterruptedException e) {
                                return;
                            }
                            break;
                        default:
                            System.out.println("Введенной команды не существует!");
                    }
                } catch (NumberFormatException e) {
                    System.out.println("После названия команды должно идти целое положительное число!");
                }
            } else if (command.length == 1 && command[0].equals("exit")) {
                exitCommand(threads);
                break;
            } else {
                System.out.println("Команда введена неверно!");
            }
        }
    }

    /*
Команда start
 */
    private static int startCommand(int counter, List<Thread> threads, int number) {
        if (number >= 1) {
         //   Thread newThread = new Thread(new RollsProbability(number), String.valueOf(counter));
        //    newThread.start();
         //   threads.add(newThread);
         //   System.out.println("Задача " + counter + " запущена.");
         //   counter++;
        } else {
            System.out.println("Количество повторений должно быть не меньше 1!");
        }
        return counter;
    }

    /*
Команда stop
 */
    private static void stopCommand(List<Thread> threads, int number) {
        if (number >= 1) {
            if ((number-1) < threads.size()) {
                Thread threadStop = threads.get(number-1);

                if (threadStop.isAlive()) {
                    threadStop.interrupt();
                } else {
                    System.out.println("Задача " + number + " уже закончена!");
                }
            } else {
                System.out.println("Задачи под номером " + number + " не существует!");
            }
        } else {
            System.out.println("Номер задачи должен быть целым положительным числом!");
        }
    }

    /*
    Команда await
     */
    private static void awaitCommand(List<Thread> threads, int number) throws InterruptedException {
        if (number >= 1) {
            if ((number-1) < threads.size()) {
                Thread threadAwait = threads.get(number-1);

                if (threadAwait.isAlive()) {
                    System.out.println("Ожидание выполнения задачи " + number);
                    threadAwait.join();
                } else {
                    System.out.println("Задача " + number + " уже закончена!");
                }
            } else {
                System.out.println("Задачи под номером " + number + " не существует!");
            }
        } else {
            System.out.println("Номер задачи должен быть целым положительным числом!");
        }
    }

    /*
    Команда exit
     */
    private static void exitCommand(List<Thread> threads) {
        for (Thread thread: threads) {
            if (thread.isAlive()) {
                thread.interrupt();
            }
        }
    }
}
