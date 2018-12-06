$("button").click(function(event) { event.preventDefault(); });

(function($) {
    $(document).ready(function() {
        $('.update-freeze-pane').click(function(e) {
            e.preventDefault();
            $('.freeze-pane').data('has-init','no');

            $('.freeze-pane').binus_freeze_pane({
                fixed_left: 0,
                on_window_load: false
            });
        });
    });
})(jQuery);

$(document).on("change","select",function() {
    $("option[value="+this.value+"]",this)
        .attr("selected",true).siblings()
        .removeAttr("selected")
});