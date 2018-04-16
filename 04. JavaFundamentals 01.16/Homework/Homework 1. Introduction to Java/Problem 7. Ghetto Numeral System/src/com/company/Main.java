package com.company;
import java.util.Scanner;
import java.util.Map;
import java.util.HashMap;
//        ?	0 – Gee
//        ?	1 – Bro
//        ?	2 – Zuz
//        ?	3 – Ma
//        ?	4 – Duh
//        ?	5  - Yo
//        ?	6 – Dis
//        ?	7 – Hood
//        ?	8 – Jam
//        ?	9 – Mack




public class Main {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String number = sc.nextLine();
        Map<Integer, String> ghettoWords = new HashMap<Integer, String>();
        ghettoWords.put(0,"Gee");
        ghettoWords.put(1,"Bro");
        ghettoWords.put(2,"Zuz"); //wtf is Zuz
        ghettoWords.put(3,"Ma");
        ghettoWords.put(4,"Duh");
        ghettoWords.put(5,"Yo");
        ghettoWords.put(6,"Dis");
        ghettoWords.put(7,"Hood");
        ghettoWords.put(8,"Jam");
        ghettoWords.put(9,"Mack");

        for(char currentDigit : number.toCharArray()){
//            int num = Character.getNumericValue(currentDigit);
//            System.out.printf(ghettoWords.get(num));
            System.out.print(ghettoWords.get(Character.getNumericValue(currentDigit)));

        }



    }
}
