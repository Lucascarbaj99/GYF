const types = {
    prodUno: 'PRODUNO',
    prodDos: 'PRODDOS'
}

$(function () {
    GetProductos();
})

function productoAColumna(producto) {
    let columna = document.createElement('td');

    let id = document.createElement('tr');
    let tipo = document.createElement('tr');
    let precio = document.createElement('tr');
    let fechaCreacion = document.createElement('tr');

    let fecha = new Date(producto.fechaCreacion).toLocaleDateString('es-AR');
    let tipoProd = producto.tipo == 0 ? types.prodUno : types.prodDos;
    id.innerHTML = producto.id;
    tipo.innerHTML = `Tipo: ${tipoProd}`;
    precio.innerHTML = `Precio: ${producto.precio}$`;
    fechaCreacion.innerHTML = `Fecha Creación: ${fecha}`;

    columna.appendChild(id);
    columna.appendChild(tipo);
    columna.appendChild(precio);
    columna.appendChild(fechaCreacion);
    return columna;
}