class GeoService{

	static async getAll(address) {
		
		const result = await Api.sendToServer(Api.ApiRoutes().Geo.getByAddress, {address});
		return result;
	}



	
}