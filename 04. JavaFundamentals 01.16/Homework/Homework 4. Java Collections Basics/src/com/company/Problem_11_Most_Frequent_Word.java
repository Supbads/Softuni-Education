package com.company;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

//Welcome to SoftUni. Welcome to Java. Welcome everyone.
//Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.

public class Problem_11_Most_Frequent_Word {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] text = sc.nextLine().toLowerCase()
                .split("\\W+");
        Map<String, Integer> wordsCount = new TreeMap<String, Integer>();
        int maxCount = 0;
        for (String word : text) {
            Integer count = wordsCount.get(word);
            if (count == null) {
                count = 0;
            }
            if (count + 1 > maxCount) {
                maxCount = count + 1;
            }
            wordsCount.put(word, count + 1);
        }

        for (Map.Entry<String, Integer> max : wordsCount.entrySet()) {
            if (max.getValue() == maxCount) {
                System.out.printf("%s -> %d times\n", max.getKey(),
                        max.getValue());
            }
        }
    }
}
