package com.company.Problem_2;


public class Appliance extends ElectronicsProduct{
    public Appliance(String name, double price, int quantity, AgeRestriction ageRestrictionLevel) {
        super(name, price, quantity, ageRestrictionLevel,6);
    }

    @Override
    public double getPrice() {
        if (this.getQuantity() < 50) {
            return this.price*1.05;
        }

        return this.price;
    }


}
