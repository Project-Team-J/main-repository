<?php

function page_word($url) {

    $page = @file_get_contents($url);

    if (!$page) return null;

    $matches = array();

    if (preg_match("/<span>(.*?)<\/span>/", $page, $matches)) {
        echo "in";
        print_r($matches);
        return $matches[1];
    }
    else {
        return null;
    }
}

#create json
$json = array(
    'word' => page_word('https://translate.google.com/#en/iw/retrospective')
);
die(json_encode($json));