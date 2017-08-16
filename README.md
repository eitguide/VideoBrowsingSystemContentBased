### Hướng dẫn cấu hình cho hệ thống

1. Cài đặt bộ giải mã video [Media Player Codec Pack](http://www.mediaplayercodecpack.com/) để hệ thống có thể xem video kết quả tìm được.

2. Tải file [Data.zip](https://drive.google.com/file/d/0B0RVmhI7YXU-eE9LVEFZT0lZczg/view?usp=sharing) (là dữ liệu index và một số file liên qua khác) và giải nén.

3. Mở project (file `./VideoBrowsingSystemContentBased/VideoBrowsingSystemContentBased.csproj`) bằng Visual Studio 2013.

4. Mở file `Config.cs` để thiết lập các đường dẫn cho các thuộc tính sau:

	* `VIDEO_DATA_PATH` gán đến thư mục chứa 4,593 video IACC.3 TRECVID 2016.
	* `FRAME_DATA_PATH` gán đến thư mục chứa các khoảng 1.6 triệu key-frame IACC.3 TRECVID 2016 (chứa các thư mục con từ `TRECVID2016_35345` đến `TRECVID2016_39937`).
	* `CAPTION_INDEX_STORAGE` gán đến thư mục `caption_indexing` đã giải nén ở bước 2.
	* `TEXTSPOTTING_INDEX_STORAGE` gán đến thư mục `textspot_indexing` đã giải nén ở bước 2.
	* `PCT_INDEX_STORAGE` gán đến thư mục `pct_indexing` đã giải nén ở bước 2.
	* `MAPPING_VIDEO_NAME_PATH` gán đến file `video_name.txt` đã giải nén ở bước 2.
	* `FPS_VIDEO_PATH` gán đến file `video_fps.xml` đã giải nén ở bước 2.
	* `COLOR_SPACE_USING` gán là `ColorSpace.Lab` nếu muốn dùng không gian màu Lab, là `ColorSpace.Rgb` nếu muốn dùng không gian màu RGB cho chức năng tìm kiếm dựa trên phác họa màu sắc.

5. Nhấn F5 để biên dịch và chạy chương trình.
