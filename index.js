var display = (function () {
    let selectedCategory = '';
    let selectedTag = '';

    function filterData() {
        $('#show > div').show();
        $('#show > div > table > tr').show();

        if (selectedTag !== '') {
            //$(`#show > div > table > tr.${selectedTag}`).show();
            $(`#show > div > table > tr`).not(`.${selectedTag}`).hide();

            $(`#show > div > table`).each(function () {
                var count = $(`#${this.id} tr:visible`).length;
                if (count === 0) {
                    $(this).parent().hide();
                }
            });
        }

        if (selectedCategory !== '') {
            //$(`#${selectedCategory}`).show();
            $('#show > div').not(`#${selectedCategory}`).hide();
        };
    }

    function clean(s) {
        return s.replace('#', 'lb')
            .replace(/[()[\]{}]\\\//i, '_')
    }

    function runDisplay(elem, data) {
        let dict = data.files.reduce((p, c) => {
            const key = c.category;
            delete c['category'];

            if (key in p) {
                p[key].push(c);
            } else {
                p[key] = [ c ];
            }
            return p;
        }, {});

        dict = Object.keys(dict).sort().reduce((r, k) => (r[k] = dict[k], r), {});

        elem.empty();

        const tagSet = new Set();
        const catSet = new Set();

        Object.keys(dict).forEach(c => {
            catSet.add(c);

            let cat = $(`<div id=${c}>`);
            cat.append($('<h2>').html(`<b><u>${c}</u></b>`));
            cat.append($('<p>'));

            let table = $(`<table id="tbl${c}">`);
            let row = table.append($('<tr>'));
            row.append($('<th>').text('Title'));
            row.append($('<th>').text('Tags'));
            row.append($('<th>').text('Description'));
            row.append($('<th>').text('File'));
            table.append(row);

            dict[c].forEach(v => {
                let ts = v.tags.replace(',', ' ');
                let row = $(`<tr class='${clean(ts)}'>`);
                let link = $('<a>').attr('href', v.file).text(v.file);
                row.append($('<td>').text(v.title));
                row.append($('<td>').text(ts));
                row.append($('<td>').text(v.description));
                row.append($('<td>').append(link));
                table.append(row);

                const t = v.tags.split(',');
                t.forEach(i => tagSet.add(i.trim()));
            });

            cat.append(table);
            elem.append(cat);
        });

        let categories = $('#categories');
        categories.append(`<option value=''></option>`);
        let sCat = Array.from(catSet).sort();
        sCat.forEach(c => categories.append($(`<option value=${clean(c)}>${c}</option>`)));

        let tags = $('#tags');
        tags.append($(`<option value=''></option>`))
        let sTags = Array.from(tagSet).sort();
        sTags.forEach(t => tags.append($(`<option value=${clean(t)}>${t}</option>`)));

        categories.on('change', function (e) {
            selectedCategory = this.value;
            filterData();
        });

        tags.on('change', function (e) {
            selectedTag = this.value;
            filterData();
        });
    };

    return { run: runDisplay };
})();
