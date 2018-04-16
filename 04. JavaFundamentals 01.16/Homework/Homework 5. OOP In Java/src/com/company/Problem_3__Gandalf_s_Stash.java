package com.company;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem_3__Gandalf_s_Stash {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int inputHappiness = sc.nextInt();
        sc.nextLine();
        String input = sc.nextLine();
        String[] splittedInput = input.toLowerCase().split("[^a-zA-Z]+");
        String text = "";
        for (String s : splittedInput) {
            text += ( s + " ");
        }

        Pattern pat = Pattern.compile("\\b(cram)\\b|\\b(lembas)\\b|\\b(apple)\\b|\\b(melon)\\b|\\b(honeycake)\\b|\\b(mushrooms)\\b", Pattern.CASE_INSENSITIVE);
        Matcher regex = pat.matcher(text);
        int others = 0;
        while(regex.find()){
            others++;
            if(regex.group(1)!=null){
                inputHappiness+=2;
            } else if(regex.group(2)!=null){
                inputHappiness+=3;
            } else if(regex.group(3)!=null){
                inputHappiness+=1;
            } else if(regex.group(4)!= null){
                inputHappiness+=1;
            } else if(regex.group(5)!= null){
                inputHappiness+=5;
            } else if(regex.group(6)!= null) {
                inputHappiness -= 10;
            }
        }
        if(others!=splittedInput.length){
            inputHappiness -= splittedInput.length-others;
        }
        System.out.println(inputHappiness);
        if(inputHappiness < -5){
            System.out.println("Angry");
        }else if(inputHappiness >=-5 && inputHappiness<=0){
            System.out.println("Sad");
        }else if(inputHappiness>15){
            System.out.println("Special JavaScript mood");
        }else if(inputHappiness>0 && inputHappiness<=15){
            System.out.println("Happy");
        }
    }

}
