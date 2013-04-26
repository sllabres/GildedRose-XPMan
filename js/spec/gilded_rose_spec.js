describe("when Gilded Rose is run", function() {

  //clears storage
  window.localStorage.clear();
  //recreates Golden Master from original
  it("should update quality", function() {
    var initday = 1;

    for (var day = 1; day < 31; day++ ) {
        o_update_quality();
        window.localStorage.setItem('day'+day, JSON.stringify(oitems));
    }

    for (var day2 = 1; day2 < 31; day2++ ) {
      update_quality();
      expect(items).toEqual(JSON.parse( window.localStorage.getItem('day'+day2)));
    }


  });

});
