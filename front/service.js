const ul = document.getElementById('productos');
const list = document.createDocumentFragment();
const urlProductos = 'https://localhost:7221/Producto/';

async function GetProductos() {
    $('ul').empty();
    await fetch(urlProductos
    ).then((response) => {
        return response.json();
    })
        .then((data) => {
            var table = document.createElement('table');
            data.map(function (producto) {
                let columna = productoAColumna(producto)
                table.appendChild(columna);
                list.appendChild(table);
            });
        })
    ul.appendChild(list);
}
async function GuardarProducto() {
    if (precioValido()) {
        await fetch(urlProductos,
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
        ).then((response) => {
            return response.json();
        })
            .then((data) => {
                if (data.success == true) {
                    alert(data.message)
                    $('table').append(productoAColumna(data.result));
                    document.getElementById("txtPrice").value = "";
                }
                else alert("Se ha producido un error al guardar")
            })
    }
    else
        alert("Verifique el monto ingresado")
}
async function BuscarPorPresupuesto() {
    let presupuesto = $('#txtPresupuesto').val();

    if (presupuestoValido()) {
        await fetch(urlProductos + `search?presupuesto=${presupuesto}`,
        ).then((response) => {
            return response.json();
        })
            .then((data) => {
                $('ul').empty();
                var table = document.createElement('table');
                data.map(function (producto) {
                    let columna = productoAColumna(producto)
                    table.appendChild(columna);
                    list.appendChild(table);
                });
            })
        ul.appendChild(list);

    }
    else
        alert("Verifique el monto ingresado")
}