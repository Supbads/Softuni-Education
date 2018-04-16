package com.company.Problem_2;


import com.company.Problem_2.Exceptions.ProductManagementException;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

public class Problem_2_1_lv_Shop {
    public static void main(String[] args) {
        FoodProduct cigars = new FoodProduct("420 Blaze it fgt Kapapride",6.90,50,AgeRestriction.Adult, "2015-11-20");
        try {
            Customer pecata = new Customer("Pecata", 17, 30.00);
            PurchaseManager.processPurchase(pecata, cigars);
        } catch (ProductManagementException e) {
            System.err.println(e.getMessage());
        }
        try{
            Customer gopeto = new Customer("Gopeto", 18, 0.44);
            PurchaseManager.processPurchase(gopeto, cigars);
        } catch(ProductManagementException f ) {
            System.err.println(f.getMessage());
        }

        ArrayList<Product> products = new ArrayList<>();
        products.add(new FoodProduct("Kremvrish Leki",2.10,30,AgeRestriction.None,"2016-06-05"));
        products.add(new Computer("Nqkaf burz i mo6ten (^:", 1200, 1500, AgeRestriction.None));
        products.add(new FoodProduct("Nacepin",999,999,AgeRestriction.Adult,"2100-06-05"));
        products.add(new FoodProduct("7Days-Max",0.80,999,AgeRestriction.None,"2015-09-04"));
        products.add(new Computer("ExtraDelux XF 11",999,200,AgeRestriction.None));
        products.add(new Appliance("Toilet",150,27,AgeRestriction.None));
        products.add(new Appliance("Stolche",35,200,AgeRestriction.Adult));

        Comparator<Product> byExpireDate = (p1,p2) -> Long.compare(
                ((FoodProduct)p1).getDaysUntilExpiry(),((FoodProduct)p2 ).getDaysUntilExpiry());
        Comparator<Product> byPrice = (p1,p2) -> Double.compare(p1.getPrice(),p2.getPrice());

        Product expirableProduct = products.stream()
                .filter(p->p instanceof Expirable)
                .sorted(byExpireDate)
                .findFirst()
                .get();

        System.out.println(expirableProduct);



        List<Product> ageRestrictionThenByPrice = products.stream()
                .filter(p1 -> p1.getAgeRestrictionLevel()==AgeRestriction.Adult)
                .sorted(byPrice)
                .collect(Collectors.toList());


        for (Product product : ageRestrictionThenByPrice) {
            System.out.println(product.toString()+"\n");
        }
    }
}
