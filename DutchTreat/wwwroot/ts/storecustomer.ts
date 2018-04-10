//export
class StoreCustomer {

    constructor(private firstName:string, private lastName:string) {
    }

    public visits: number = 0;
    private ourname: string;

    public showName() {
        alert(this.firstName + " " + this.lastName);
    }

    set name(val) {
        this.ourname = val;
    }

    get name() {
        return this.ourname;
        
    }
}

//let cust = new StoreCustomer();
//cust.visits = 10;