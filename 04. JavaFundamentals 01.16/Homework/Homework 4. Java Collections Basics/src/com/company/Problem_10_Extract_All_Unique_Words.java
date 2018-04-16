package com.company;
import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;

//What is better: Java SE or Java EE?
//Welcome to SoftUni. Welcome to Java.

public class Problem_10_Extract_All_Unique_Words {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        String[] input = sc.nextLine().toLowerCase()
                .split("\\W+");
        Set<String> words = new TreeSet<>();
        for (String string : input) {
            words.add(string);
        }
        for (String str : words) {
            System.out.print(str + " ");
        }
    }
}
