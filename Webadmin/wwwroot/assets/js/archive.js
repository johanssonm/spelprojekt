function getNews(callback) {
    $.ajax({
        type: "GET",
        url: "../api/values/",
        success: function(response){
            callback(response);
        }
    })
    
}

$(function(){
    var $records = getNews(drawTable);

    function drawTable(result){
        $("#myTable").dynatable({
            dataset: {
                records: result
              }
        });
    
    }


})

$("#myTable").prop("class", "table table-striped");

$("#dynatable-query-search-myTable").prop("class", "form-control");

