package com.company;
import java.util.ArrayList;
import java.util.Scanner;

//2 3 4 1 50 2 3 4 5
//1 2 3 4 5 6 7 8 9
public class Problem_4__Longest_Increasing_Sequence {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String[] numbersStrings = sc.nextLine().split(" ");
        int[] numbers = new int[numbersStrings.length];
        for (int i = 0; i < numbers.length; i++) {
            numbers[i] = Integer.parseInt(numbersStrings[i]);
        }

        ArrayList<ArrayList<Integer>> sequences = new ArrayList<>();
        ArrayList<Integer> sequence = new ArrayList<>();
        sequence.add(numbers[0]);

        for (int i = 1; i < numbers.length; i++) {

            if (numbers[i] > numbers[i - 1]) {
                sequence.add(numbers[i]);
            } else {
                sequences.add(sequence);
                sequence = new ArrayList<>();
                sequence.add(numbers[i]);
            }
        }
        sequences.add(sequence);
        for (ArrayList<Integer> seq : sequences) {
            for (Integer integer : seq) {
                System.out.print(integer + " ");
            }
            System.out.println();
        }
        ArrayList<Integer> longest = new ArrayList<>();
        for (int i = 1; i < sequences.size(); i++) {
            if (sequences.get(i).size() > sequences.get(i - 1).size()) {
                longest = sequences.get(i);
            }
        }
        System.out.print("Longest: ");
        for (Integer integer : longest) {
            System.out.print(integer + " ");
        }
    }

}
