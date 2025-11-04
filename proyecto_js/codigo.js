document.addEventListener("DOMContentLoaded", () =>{
	const selectPropiedad = document.getElementById("propiedad");
	const selectUbicacion = document.getElementById("ubicacion");

	function cargarComboPropiedad() {

		let html = `<option disabled selected>...</option>`;

		datosPropiedad.forEach(item => {
			html += `<option value="${item.factor}">${item.tipo}</option>`;
		});

		selectPropiedad.innerHTML = html;
	}
	
	function cargarComboUbicacion() {

		let html = `<option disabled selected>...</option>`;

		datosUbicacion.forEach(item => {
			html += `<option value="${item.factor}">${item.tipo}</option>`;
		});

		selectUbicacion.innerHTML = html;
	}

	cargarComboPropiedad();
	cargarComboUbicacion();

	document.getElementById("btnCotizar").addEventListener("click", () => {
		const boton = document.getElementById("btnCotizar");
		const contenedor = document.querySelector(".div-quote");

		contenedor.classList.add("div-blocked");

		boton.innerHTML = `<img src="imagenes/animation.gif" alt="Cargando ..." style="height:20px;">`;

		setTimeout(() => {
			calcularPoliza();

		boton.textContent = "Cotizar";

		contenedor.classList.remove("div-blocked");
		}, 1000);
	});
});

function obtenerFactores(tipoPropiedad, tipoUbicacion) {
	let factorPropiedad = null;
	let factorUbicacion = null;

	for (let i = 0; i < datosPropiedad.length; i++) {
		if (datosPropiedad[i].tipo === tipoPropiedad) {
			factorPropiedad = datosPropiedad[i].factor;
			break;
		}
	}

	for (let i = 0; i < datosUbicacion.length; i++) {
		if (datosUbicacion[i].tipo === tipoUbicacion) {
			factorUbicacion = datosUbicacion[i].factor;
			break;
		}
	}

	return {
		propiedad: factorPropiedad,
		ubicacion: factorUbicacion
	};
}

	function calcularPoliza() {
		const metros = parseInt(document.getElementById("metros").value);
		const selectPropiedad = document.getElementById("propiedad");
		const selectUbicacion = document.getElementById("ubicacion");
		const tipoPropiedad = selectPropiedad.selectedOptions[0].textContent;
		const tipoUbicacion = selectUbicacion.selectedOptions[0].textContent.split(" -")[0];
		const fmPropiedad = parseFloat(selectPropiedad.value);
		const fmUbicacion = parseFloat(selectUbicacion.value);
		const costoBase = 1.16;

		const contenedor = document.querySelector(".div-quote");
		contenedor.classList.add("div-blocked");

	if (
	  Number.isInteger(metros) &&
	  metros >= 20 && metros <= 500 &&
	  fmPropiedad && fmUbicacion
	) {
		const valorPoliza = costoBase * metros * fmPropiedad * fmUbicacion;
	    const valorFormateado = valorPoliza.toLocaleString("es-US", {
	    	style: "currency",
	    	currency: "USD",
	    	minimumFractionDigits: 2,
	    	maximumFractionDigits: 2
	    });
	    document.getElementById("valorPoliza").textContent = valorPoliza.toFixed(2);
	    console.log("Tipo de Propiedad:", tipoPropiedad);
	    console.log("Ubicacion:", tipoUbicacion);
	    console.log("Metros cuadrados:", metros);
	    console.log("Resultado de la póliza: U$D", valorPoliza);

	    const boton = document.getElementById("btnCotizar");
	    boton.classList.add("button-animado");
	   } else {
	   	console.warn("No se pudo calcular la póliza. Verificá los datos ingresados");
	   } 
	}

	



