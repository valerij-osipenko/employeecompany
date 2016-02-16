$(document).ready(function () {
        $('.pagination li a').each(function () {
            var hover = $(this).attr('href');
            var addattr = hover + '&statustype=' + $('#statusId').val();
            
            $(this).attr('href', addattr);
        });
    $("form").validate({            
       rules: {
           Name: {
               required: true,
               Name : true,
               minlength : 3
           },
           Post : {
               required: true,
               Post: true,
               minlength: 3
           },
           Salary : {
               required: true,
               Salary : true
           }
       },
       messages : {
           Name : {
               required : "Количество символов не менее 3"
           },
           Post: {
               required: "Количество символов не менее 3"
           },
           Salary : {
               required : "Поле должно быть заполнено"
           }
       }
    });

    $(function () {
        $("[data-autocomplete-source]").each(function () {
            var target = $(this);
            target.autocomplete({ source: target.attr("data-autocomplete-source") });
        });
    });
});