package com.company;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

//Gosho gos pesho pes blabla bla
//To be, or not to be.
public class Problem_13_Filter_Array {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split("\\W+");
        ArrayList<String> list = new ArrayList<String>(Arrays.asList(input));


        firstFilter(list);

        secondFilter(input, list);

    }

    private static void firstFilter(ArrayList<String> list) {
        System.out.println("First filter:");
        list.stream().filter(p->p.length()>3).forEach(e -> System.out.print(e + " "));
        System.out.println();
    }

    private static void secondFilter(String[] input, ArrayList<String> list) {
        for (String s : input) {
            list.add(s);
        }

        ArrayList<String> filtered= runFilter(list);
        System.out.println("Second filter:");
        for (String s : filtered) {
            System.out.printf(s + " ");
        }
    }

    private static ArrayList<String> runFilter(ArrayList<String> list) {
        for (int i = 0; i < list.size(); i++) {
            boolean action = false;
            if(list.get(i).length() <=3){
                list.remove(i);
                action=true;
            }
            if(action){
                i--;
            }
        }
        return list;
    }
}
