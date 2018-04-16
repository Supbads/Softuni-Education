package com.company;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;


//hi yes yes yes bye
//1 1 2 2 3 3 4 4 5 5
//a b b xxx c c c
public class Problem_3_Largest_Sequence_of_Equal_Strings {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] array = sc.nextLine().split(" ");
        Map<String, Integer> counters = new TreeMap<String, Integer>();

        for (String string : array) {
            Integer count = counters.get(string);
            if (count == null) {
                count = 0;
            }
            counters.put(string, count + 1);
        }

        Map.Entry<String, Integer> maxEntry = null;
        for (Map.Entry<String, Integer> entry : counters.entrySet()) {
            if (maxEntry == null
                    || entry.getValue().compareTo(maxEntry.getValue()) > 0) {
                maxEntry = entry;
            }
        }
        for (int i = 0; i < maxEntry.getValue(); i++) {
            System.out.print(maxEntry.getKey() + " ");
        }

    }
}
