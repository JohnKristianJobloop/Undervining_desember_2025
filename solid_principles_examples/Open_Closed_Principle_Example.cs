using System;

namespace solid_principles_examples;

/* 
public decimal CaculateDiscontForCustomerType(CustomerTypes type, decimal amount)
    {
        return type switch
        {
            CustomerTypes.Regular => amount * 0.95m,
            CustomerTypes.Vip => amount * 0.80m,
            CustomerTypes.SuperVip => amount * 0.75m,
            CustomerTypes.SuperDuperVip => amount * 0.70m,
            _ => throw new NotSupportedException("Unknown customer type")
        };
    }

}

public enum CustomerTypes
{
    Regular,
    Vip,
    SuperVip,
    SuperDuperVip
}
 */

public class Open_Closed_Principle_Example
{
    public decimal CaculateDiscontForCustomerType(CustomerTypes type, decimal amount) => amount * ((decimal)type / 100);

}

public enum CustomerTypes
{
    Regular = 5,
    Vip = 20,
    SuperVip = 25,
    SuperDuperVip = 30
}


