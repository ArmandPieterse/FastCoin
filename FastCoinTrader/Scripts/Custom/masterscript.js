//Sales Functionality
$(document).ready(function () {
    //===========================TOTAL EVENTS START==================================
    $("#total").on("focus", function () { $(this).val(removeCurrency(getTotal())); });

    $("#total").on("focusout", function () { $(this).val(addCurrency(getTotal())); });

    $("#total").change(function () {
        
        if (getPrice() > 0)
        {                  
            $("#amount").val(addBTC(getTotal() / getPrice()));
        }
        else if (getAmount() > 0)
        {
            $("#price").val(addCurrency(getTotal() / getAmount()));
        }
        setFee();
    });
    //===========================TOTAL EVENTS END==================================

    //===========================PRICE EVENTS START==================================
    $("#price").on("focus", function () { $(this).val(getPrice()); });
    $("#price").on("focusout", function () { $(this).val(addCurrency(getPrice())); });
    $("#price").change(function () {
        if (getAmount() !== null && $("#amount").val() !== null) {
            var total = getAmount() * getPrice();
            $("#total").val(addCurrency(total));
        }
        setFee();
    });

    //===========================PRICE EVENTS END==================================

    //===========================AMOUNT EVENTS START==================================
    $("#amount").on("focus", function () { $(this).val(getAmount()); });
    $("#amount").on("focusout", function () { $(this).val(addBTC(getAmount())); });
    $("#amount").change(function () {        
        if (getPrice() !== null && getAmount() !== null)
        {
            var total = getAmount() * getPrice();
            $("#total").val(addCurrency(total));
        }
        setFee();
    });
    //===========================PRICE EVENTS END==================================

    $(".btn-primary").click(function () {
        if ($(this).html().indexOf("Sell") !== -1)
        {           
            $('#myModal').modal('show');
            //$('#myModal').modal('hide');
        }
        else if ($(this).html().indexOf("Buy") !== -1)
        {
            alert();
        }
    });
    
});
//===============================SELL && BUY SCREEN FUNCTIONS START====================================
function setFee()
{
    $("#fee").val(addBTC(getAmount() * 0.05));
}

function getTotal()
{
    return removeCurrency($("#total").val());
}

function getAmount()
{
    return removeBTC($("#amount").val());
}

function getPrice()
{
    return removeCurrency($("#price").val());
}

function removeCurrency(value)
{
    return Number(value.replace("R ","")).toFixed(2);
}

function addCurrency(value)
{
    return "R " + Number(value).toFixed(2);
}

function removeBTC(value)
{
    return Number(value.replace("BTC ", "")).toFixed(8);
}

function addBTC(value)
{
    return "BTC " + Number(value).toFixed(8);
}

function submitForm()
{
    $('#myModal').modal('hide');
}

function closeModal()
{
    $('#myModal').modal('hide');
}
function checkAll ()
{
    if (getAmount() > 0 && getPrice() > 0 && getTotal() > 0)
    {
        $('.btn-primary').close
    }
}

//===============================SELL && BUY SCREEN FUNCTIONS END====================================

