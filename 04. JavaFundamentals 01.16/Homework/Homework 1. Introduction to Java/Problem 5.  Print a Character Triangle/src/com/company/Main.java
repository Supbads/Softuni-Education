package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int number = Integer.parseInt(sc.nextLine());
        for (int i = 1; i <= number; i++) {
            for (char j = 'a'; j < 'a'+i; j++) {
                System.out.print(j + " ");

            }
            System.out.println(" ");
        }
        for (int i = number-1; i >=0; i--) {
            for (char j = 'a'; j < 'a' + i; j++) {
                System.out.print(j + " ");

            }
        System.out.println();
        }
    }
}
