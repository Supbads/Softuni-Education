package com.company;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class Problem_6_User_Logs {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String pattern="IP\\s*=\\s*([^ ]+)\\s+message\\s*=\\s*'.*'\\s*user\\s*=\\s*([^\\s]+)";
        Pattern pat = Pattern.compile(pattern);

        StringBuilder sb = new StringBuilder();
        String input = sc.nextLine();
        while(!input.equals("end")){
            sb.append(input+"\n");
            input=sc.nextLine();
        }
        String text = sb.toString();
        Matcher match = pat.matcher(text);

        //       ime        ip      counter
        TreeMap<String,LinkedHashMap<String,Integer>> person = new TreeMap<String,LinkedHashMap<String,Integer>>();

        while(match.find()){
            String username = match.group(2);
            String ip = match.group(1);

            addUserData(person, username, ip);

            //addDataCoppied(person, username, ip);
        }
        
        for (Map.Entry<String,LinkedHashMap<String,Integer>> s : person.entrySet()) {
            System.out.println(s.getKey()+":");  // <- user

            LinkedHashMap<String, Integer> hashMap = s.getValue();
            //  ^
            // so that we can keep everything in order and correctly get last element + method to work

            for(Map.Entry<String,Integer> secondEntry : s.getValue().entrySet()) {
                String lastIP = getLastKey(hashMap);
                System.out.print(secondEntry.getKey() + " => " + secondEntry.getValue());
                if(lastIP==secondEntry.getKey()){
                    System.out.println(".");
                } else{
                    System.out.println(",");
                }
            }

        }
    }

    private static void addDataCoppied(TreeMap<String, LinkedHashMap<String, Integer>> person, String username, String ip) {
        if (!person.containsKey(username)) {
            person.put(username, new LinkedHashMap<String, Integer>());
            person.get(username).put(ip, 1);
        }
        else {
            Integer count = 0;
            if (person.get(username).containsKey(ip)) {
                count = person.get(username).get(ip);
            }

            person.get(username).put(ip, count + 1);
        }
    }

    private static void addUserData(TreeMap<String, LinkedHashMap<String, Integer>> person, String username, String ip) {
        if(!person.containsKey(username)){
            person.put(username, new LinkedHashMap<String,Integer>());
        }
        if(!person.get(username).containsKey(ip)){
            person.get(username).put(ip,1);
        }
        else{
            person.get(username).put(ip, person.get(username).get(ip) + 1);
        }
    }

    public static String getLastKey(LinkedHashMap<String, Integer> hashMap) {
        String out = "";
        for (String key : hashMap.keySet()) {
            out = key;
        }
        return out;
    }
}
