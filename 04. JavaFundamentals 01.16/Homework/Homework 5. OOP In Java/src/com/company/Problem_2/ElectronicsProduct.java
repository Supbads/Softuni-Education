package com.company.Problem_2;
import com.company.Problem_2.Exceptions.ProductManagementException;

public abstract class ElectronicsProduct extends Product {
    private int guaranteePeriod;

    public ElectronicsProduct(String name, double price, int quantity,
                              AgeRestriction ageRestrictionLevel, int guaranteePeriod) {
        super(name, price, quantity, ageRestrictionLevel);
        this.setGuaranteePeriod(guaranteePeriod);
    }

    public int getGuaranteePeriod() {
        return this.guaranteePeriod;
    }

    public void setGuaranteePeriod(int guaranteePeriod) {
        if (guaranteePeriod < 0) {
            throw new IllegalArgumentException("Guarantee period cannot be negative");
        }

        this.guaranteePeriod = guaranteePeriod;
    }

    @Override
    public String toString() {
        return super.toString() +
                "Guarantee period: " + this.guaranteePeriod;
    }

}
