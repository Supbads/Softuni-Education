package com.company;
import java.util.*;

//6 8 3 1 7 2 2 5
//Ascending
//6 8 3 1 7 2 2 5
//Descending
public class Problem_14_Sort_array_with_stream_API {
    public static void main(String[] args) {
        //not working
        Scanner sc = new Scanner(System.in);
        String[] input = sc.nextLine().split("\\W+");
        ArrayList<Integer> list = new ArrayList<>();
        for (String s : input) {
            list.add(Integer.parseInt(s));
        }

        String command = sc.nextLine();

        if (command.equals("Ascending")) {
            list.stream().forEach(e -> System.out.print(e + " "));
        }
        else if(command.equals("Descending")){ //or sort once and reverse
            Collections.reverse(list);
            list.stream().sorted((num1, num2) -> num2.compareTo(num1));
            list.forEach(e -> System.out.print(e+" "));
        }


    }
}
