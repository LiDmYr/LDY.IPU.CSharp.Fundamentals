using System;
using LDY.IPU.CSharp.Fundamentals.Class5.OOP_Classes.Factory.Services;

namespace LDY.IPU.CSharp.Fundamentals.Class5.OOP_Classes.Factory {
    internal class Factory {
        public Worker[] Workers { get; private set; }

        public Order[] Orders { get; private set; }

        private readonly Logger Logger;

        public Factory(Worker[] workers, Order[] orders, Logger logger) {
            this.Workers = workers;
            this.Orders = orders;
            this.Logger = logger;
        }

        internal Report StartWorkingDay() {
            foreach (Worker worker in this.Workers) {
                Order notCompletedOrder = this.GetNotCompletedOrder();
                Item notCompletedItem = this.GetNotCompletedItem(notCompletedOrder);
                if (notCompletedItem == null) {
                    this.Logger.LogError("FACTORY IS STOPPED");
                    return new Report("STOPPED");
                }
                notCompletedItem.ChangeProgress(worker.Capacity);
                this.DoSomething(notCompletedItem);
                this.PrintWorkResultForWorker(worker, notCompletedOrder, notCompletedItem);
            }
            return new Report("ALL IS GOOD");
        }

        private void DoSomething(Item notCompletedItem) {
            notCompletedItem.WholeCapacity = this.GetNewCapacity();
        }

        private int GetNewCapacity() {
            return 10;
        }

        private void PrintWorkResultForWorker(Worker worker, Order notCompletedOrder, Item notCompletedItem) {
            string message = $"{worker.Name} made for order#{notCompletedOrder.Id} with Item#{notCompletedItem.Name} with Capacity #{worker.Capacity}";
            this.Logger.LogInfo(message);
        }


        private Item GetNotCompletedItem(Order notCompletedOrder) {
            foreach (Item item in notCompletedOrder.Items) {
                if (!item.IsCompleted) {
                    this.Logger.LogInfo("Item" + item.Name + "is not completed");
                    return item;
                }
            }
            return null;
        }

        private Order GetNotCompletedOrder() {
            foreach (Order order in this.Orders) {
                if (!order.IsCompleted) {
                    this.Logger.LogInfo("order" + order.Id + "is not completed");
                    return order;
                }
            }
            return this.Orders[this.Orders.Length - 1];
        }

    }
}
