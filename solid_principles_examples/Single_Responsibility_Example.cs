using System;

namespace solid_principles_examples;

public class Single_Responsibility_Example(IDatabaseHandler databaseHandler, IEmailHandler emailHandler, IFileHandler fileHandler)
{
    public void HandleOrder(Order order)
    {
        databaseHandler.SaveToDatabase(order);

        emailHandler.SendEmail(order.Email, "Thanks for ordering the product!");

        fileHandler.AppendOrderToLogFile(order.Id);
    }
    /* public void HandleOrder(Order order)
    {
        AppendOrderToLogFile(order.Id, "./order_log.txt");

        SaveOrderToDatabase(order);

        SendEmail(order.Email, "Thanks for ordering the product!");
    }
    private void AppendOrderToLogFile(int orderId, string fileLocation)
    {
        
    }
    private void SendEmail(string email, string emailBody)
    {
        
    }
    private void SaveOrderToDatabase(Order order)
    {
        
    } */
}

public interface IDatabaseHandler
{
    void SaveToDatabase(Order order);
}

public interface IEmailHandler
{
    void SendEmail(string email, string emailBody);
}

public interface IFileHandler
{
    void AppendOrderToLogFile(int orderId);
}

public record Order(int Id, string Email, decimal TotalCost);
