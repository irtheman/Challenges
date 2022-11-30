var display = (function () {
    let selectedCategory = '';
    let selectedTag = '';

    function filterData() {
        if (selectedCategory !== '') {
            $(`#${selectedCategory}`).show();
            $('#show > div').not(`#${selectedCategory}`).hide();
        } else {
            $('#show > div').show();
        };

        if (selectedTag !== '') {
            $(`#show > div > table > tr.${selectedTag}`).show();
            $(`#show > div > table > tr`).not(`.${ selectedTag }`).hide();
        } else {
            $('#show > div > table > tr').show();
        }
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

        console.log(JSON.stringify(dict));

        elem.empty();

        const tagSet = new Set();
        let categories = $('#categories');
        categories.append(`<option value=''></option>`);

        Object.keys(dict).forEach(c => {
            categories.append(`<option value=${c}>${c}</option>`);

            let cat = $(`<div id=${c}>`);
            cat.append($('<h3>').html('<u>' + c + '</u>'));
            cat.append($('<p>'));

            let table = $('<table width="75%" border="1">');
            let row = table.append($('<tr>'));
            row.append($('<th width="500">').text('Title'));
            row.append($('<th width="200">').text('Tags'));
            row.append($('<th width="1000">').text('File'));
            table.append(row);

            dict[c].forEach(v => {
                let ts = v.tags.replace(',', ' ');
                let row = $(`<tr class='${ts}'>`);
                row.append($('<td>').text(v.title));
                row.append($('<td>').text(ts));
                row.append($('<td>').text(v.file).attr('href', v.file));
                table.append(row);

                const t = v.tags.split(',');
                t.forEach(i => tagSet.add(i.trim()));
            });

            cat.append(table);
            elem.append(cat);
        });

        let tags = $('#tags');
        tags.append($(`<option value=''></option>`))
        tagSet.forEach(t => tags.append($(`<option value=${t}>${t}</option>`)));

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
