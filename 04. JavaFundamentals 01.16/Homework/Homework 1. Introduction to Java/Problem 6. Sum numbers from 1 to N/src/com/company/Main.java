package com.company;
import java.util.Scanner;
import java.lang.System;
public class Main {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int number = Integer.parseInt(sc.nextLine());
        int sum =0;
        for (int i = 1; i <=number; i++) {
            sum+=i;
        }
        System.out.println(sum);

    }
}

