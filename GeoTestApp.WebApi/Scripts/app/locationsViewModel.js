
function LocationsViewModel() {
	var self = this;

	self.locationViewModel = ko.observable(new LocationViewModel(0, ''));
	self.locationsLoadingState = ko.observable();
	
	self.locations = ko.observableArray();
 
	self.addlocation = async function () {

		if (!self.locationViewModel().address()) {

			self.locationViewModel().errors(['Введите адрес']);
			return;
        }

		self.locationViewModel().isSendingToServer(true);
		
		const result = await GeoService.getAll(self.locationViewModel().address());

		console.log(result);

		if(result.isSuccess)
		{

			self.locations.push(new LocationViewModel(new Location(0, self.locationViewModel().address(), result.data)));
            
			self.locationViewModel().errors([]);
			self.locationViewModel().address('');
		}else{
			self.locationViewModel().errors(result.errors);
		}

		self.locationViewModel().isSendingToServer(false);

	};
    
 
	

	
    
}

ko.applyBindings(new LocationsViewModel());