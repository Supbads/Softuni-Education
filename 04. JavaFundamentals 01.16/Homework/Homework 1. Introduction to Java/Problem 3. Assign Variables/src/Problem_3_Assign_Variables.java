import java.text.MessageFormat;

public class Problem_3_Assign_Variables {
     public static void main(String[] args){
        //false, “Palo Alto, CA”, 32767, 2000000000, 0.1234567891011, 0.5f, 919827112351L, 127, ‘c’
        Boolean first = false;
        String second = "Palo Alto, CA";
        short third = 32767;
        int fourth = 2000000000;
        double fifth = 0.1234567891011;
        float sixth = 0.5f;
        long seventh = 919827112351L;
        byte eighth = 127;
        char ninth = 'c';

        System.out.println(MessageFormat.format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", first, second,
                third, fourth, fifth, sixth, seventh, eighth, ninth));

//         short test = 32768;
    }
}
