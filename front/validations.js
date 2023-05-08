$("#txtPrice").keyup(function () {
    !precioValido() ? $('#errorMsg').show() : $('#errorMsg').hide();
});

function precioValido() {
    let price = $('#txtPrice').val();
    return (!(price > 999999 || price == '' || price == 0))
};

$("#txtPresupuesto").keyup(function () {
    !presupuestoValido() ? $('#errorMsgPresupuesto').show() : $('#errorMsgPresupuesto').hide();
});

function presupuestoValido() {
    let price = $('#txtPresupuesto').val();
    return (!(price > 1000000 || price == '' || price == 0))
};


const validaNumericos = (event) => (event.charCode >= 48 && event.charCode <= 57)