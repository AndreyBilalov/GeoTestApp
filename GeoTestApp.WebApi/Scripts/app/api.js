class Api{

	static async sendToServer(route, data){

		const options = this.formOptions(route, data);

		try {

			const result = await axios(options);
	
			return new HttpRequestResult(true, [], result.data);

		} catch (error) {
			console.log(error);
			const errors = HttpErrorHandler.getErrors(error);
			return new HttpRequestResult(false, errors);
		}
        
	}

	static formOptions(route, data){
		
		if(route.url.includes('?address='))
		{
			route.url = route.url.replace('?address=',`?address=${data.address}`)
		};

		return {
			method: route.method,
			data: data,
			url:route.url
		};

	}

	static ApiRoutes() {
		return {
			Geo:{
				getByAddress: {url: '/api/geo/get?address=', method: 'get'},

			}}};
};

class HttpRequestResult{
	constructor(isSuccess, errors, data){
		this.isSuccess = isSuccess;
		this.errors = errors;
		this.data = data;
	}
};

class HttpErrorHandler{

	static getErrors(error){

		let errors = [];

		if (error.response) {
			errors.push(error.response.data);
		} else if (error.request) {
			errors.push(error.request.data);
		} else {
			errors.push(error.message);
		}
		
		return errors;
	};
};
