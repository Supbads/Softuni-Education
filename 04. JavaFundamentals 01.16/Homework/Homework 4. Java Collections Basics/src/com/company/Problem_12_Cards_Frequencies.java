package com.company;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

//8? 2? 4? 10? J? A? K? 10? K? K?
//J? 2? 2? 2? 2? 2? 2? J? 2?

public class Problem_12_Cards_Frequencies {
    public static void main(String[] args) {
        try (Scanner sc = new Scanner(System.in)) {
            String[] cards = sc.nextLine().split("[???? ]+");
            int N = cards.length;

            Map<String, Integer> cardOccurrences = new LinkedHashMap<String, Integer>();

            for (String card : cards) {
                Integer count = cardOccurrences.get(card);
                if (count == null) {
                    count = 0;
                }
                cardOccurrences.put(card, count + 1);
            }

            for (Map.Entry<String, Integer> entry : cardOccurrences.entrySet()){
                System.out.printf("%s -> %.2f%%\n", entry.getKey(),
                        (double)entry.getValue() * 100 / N);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }

    }
}
