namespace Order.Microservice.Infra.Queries
{
    public static class OrderQuery
    {
        public static string CreateOrder { get; set; } = @"
            INSERT INTO
                OrderMicroserviceOrder
                (Id, CreateAt, OrderStatus)
            VALUES
                (@Id, @CreateAt, @OrderStatus);
        ";

        public static string CreateItem { get; set; } = @"
            INSERT INTO
                OrderMicroserviceOrderItem
                (Id, Value, OrderId, ItemId)
            VALUES
               (@Id, @Value, @OrderId, @ItemId);
        ";

        public static string GetAll { get; set; } = @"
            SELECT 
                [order].*,
                item.*
            FROM 
                OrderMicroserviceOrder [order]
            INNER JOIN 
                OrderMicroserviceOrderItem item ON [order].Id = item.OrderId;       
        ";
    }
}