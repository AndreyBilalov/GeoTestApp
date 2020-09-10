

class LocationViewModel{

	constructor(location){
		this.id = location.id;
		this.address = ko.observable(location.address);
		this.coordinates = location.coordinates;
        
		this.isSendingToServer = ko.observable(false);
        
		this.errors = ko.observableArray();
	}
    
	async save() {

		console.log(this.coordinates);

		

	}

}