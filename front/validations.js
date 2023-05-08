$("#txtPrice").keyup(function () {
    !precioValido() ? $('#errorMsg').show() : $('#errorMsg').hide();
});
function precioValido() {
    let price = $('#txtPrice').val();
    if (price > 999999 || price == '' || price == 0)
        return false;
    return true;
};

$("#txtPresupuesto").keyup(function () {
    !presupuestoValido() ? $('#errorMsgPresupuesto').show() : $('#errorMsgPresupuesto').hide();
});
function presupuestoValido() {
    let price = $('#txtPresupuesto').val();
    if (price > 1000000 || price == '' || price == 0)
        return false;
    return true;
};


function validaNumericos(event) {
    if (event.charCode >= 48 && event.charCode <= 57) {
        return true;
    }
    return false;
}