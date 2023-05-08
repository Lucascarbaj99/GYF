const ul = document.getElementById('productos');
const list = document.createDocumentFragment();
const urlProductos = 'https://localhost:7221/Producto/';

async function GetProductos() {
    $('ul').empty();
    const response = await fetch(urlProductos);
    const data = await response.json();
    var table = document.createElement('table');
    data.map(function (producto) {
        let columna = productoAColumna(producto)
        table.appendChild(columna);
        list.appendChild(table);
    });
    ul.appendChild(list);
}
async function GuardarProducto() {
    if (precioValido()) {
        const response = await fetch(urlProductos,
            {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    tipo: parseInt($('#ddlCategory').find(":selected").val()),
                    precio: $('#txtPrice').val(),
                })
            }
        )
        const data = await response.json();
        if (data.success) {
            $('table').append(productoAColumna(data.result));
            document.getElementById("txtPrice").value = "";
        }
        alert(data.message);
    }
    else
        alert("Verifique el monto ingresado")
}
async function BuscarPorPresupuesto() {
    let presupuesto = $('#txtPresupuesto').val();

    if (!presupuestoValido()) {
        alert("Verifique el monto ingresado")
        return
    }

    const response = await fetch(urlProductos + `search?presupuesto=${presupuesto}`)
    const data = await response.json();
    $('ul').empty();
    const table = document.createElement('table');
    data.map((producto) => {
        let columna = productoAColumna(producto)
        table.appendChild(columna);
        list.appendChild(table);
    });
    ul.appendChild(list);
}