<?php
/**
 * Created by PhpStorm.
 * User: user
 * Date: 29/03/2017
 * Time: 15:44
 */
class DAILYWORD
{
    private $word;
    private $image;

    function __construct()
    {
        $this->word = array(
            'word'=>$this->page_word('https://www.merriam-webster.com/word-of-the-day'));
        $this->word=$this->word['word'];
        $this->image=$this->images($this->word);

    }
    function page_word($url)
    {

        $page = @file_get_contents($url);

        if (!$page) return null;

        $matches = array();

        if (preg_match('/<h1>(.*?)<\/h1>/', $page, $matches)) {
            return $matches[1];
        } else {
            return null;
        }
        #create json

    }
    function images($word)
    {
        $html = @file_get_contents('https://www.google.co.il/search?q='.$word.'&espv=2&source=lnms&tbm=isch&sa=X&ved=0ahUKEwifoPbzkYDTAhUHuBQKHdaBCmQQ_AUIBigB&biw=1280&bih=615');
        preg_match_all( '|<img.*?src=[\'"](.*?)[\'"].*?>|i',$html, $matches );
        return $matches[ 1 ][ 2];
    }
    function get_word()
    {
        return $this->word;
    }
    function get_image()
    {
        return $this->image;
    }
}
$day=new DAILYWORD;
$day=$day->get_image();
echo $day;
?>
<html>
<img src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQMdqxU72901aO3ioI_BXgGagsOO5FWe8qoxBJE3O058GK9x2XfHWe-1r9_' alt="Smiley face" height="200" width="200">

</html>



