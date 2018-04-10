//export
var StoreCustomer = /** @class */ (function () {
    function StoreCustomer(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.visits = 0;
    }
    StoreCustomer.prototype.showName = function () {
        alert(this.firstName + " " + this.lastName);
    };
    Object.defineProperty(StoreCustomer.prototype, "name", {
        get: function () {
            return this.ourname;
        },
        set: function (val) {
            this.ourname = val;
        },
        enumerable: true,
        configurable: true
    });
    return StoreCustomer;
}());
//let cust = new StoreCustomer();
//cust.visits = 10; 
//# sourceMappingURL=storecustomer.js.map