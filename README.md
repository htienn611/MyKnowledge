# MyKnowledge

# remove tracking

-> git rm -r --cached <path>/

# how to use .gitignore

Mô Tả ## Công Thức Cấu Hình ## Giải Thích
-> Bỏ qua tất cả các tệp có phần mở rộng .txt ## _.txt ## Bỏ qua tất cả các tệp có phần mở rộng .txt trong toàn bộ dự án.
-> Bỏ qua thư mục folder_name ở cấp thư mục hiện tại ## /folder_name/ ## Bỏ qua thư mục có tên folder_name chỉ ở cấp thư mục hiện tại (thư mục gốc của dự án).
-> Bỏ qua thư mục folder_name trong toàn bộ dự án ## \*\*/folder_name/ ## Bỏ qua tất cả các thư mục có tên folder_name ở mọi cấp độ trong dự án (bao gồm cả thư mục con).
-> Bỏ qua tất cả các tệp có tên bắt đầu với prefix ## prefix_ ## Bỏ qua tất cả các tệp có tên bắt đầu bằng prefix (ví dụ: prefix*file, prefix_example.txt).
-> Bỏ qua tất cả các thư mục có tên bắt đầu với prefix ## prefix*/ ## Bỏ qua tất cả các thư mục có tên bắt đầu bằng prefix (ví dụ: prefix*folder, prefix_subfolder/).
-> Bỏ qua các tệp .log ## *.log ## Bỏ qua tất cả các tệp có phần mở rộng .log.
-> Bỏ qua tất cả các tệp và thư mục bắt đầu bằng dấu chấm (như .git, .env) ## ._ ## Bỏ qua tất cả các tệp và thư mục có tên bắt đầu bằng dấu chấm (thường dùng cho tệp cấu hình, như .git, .env).
-> Bỏ qua tệp .env ## .env ## Bỏ qua tệp .env (thường chứa các biến môi trường hoặc thông tin nhạy cảm).
-> Bỏ qua thư mục build/ nhưng giữ lại tệp cấu hình trong thư mục đó ## 1: build/_
2: !build/config.json ## Bỏ qua tất cả các tệp trong thư mục build/, nhưng giữ lại tệp config.json.
-> Bỏ qua tất cả các tệp trong thư mục logs/ ## logs/\_ ## Bỏ qua tất cả các tệp trong thư mục logs/.
-> Bỏ qua tất cả các tệp .txt trong thư mục folder*name ## folder_name/*.txt ## Bỏ qua tất cả các tệp .txt chỉ trong thư mục folder_name.
-> Bỏ qua tất cả các tệp .txt trong mọi thư mục con ## **/\*.txt ## Bỏ qua tất cả các tệp .txt trong tất cả các thư mục con của dự án, không kể vị trí.
-> Bỏ qua tệp có tên file_name.txt ở cấp thư mục gốc ## /file_name.txt ## Bỏ qua tệp có tên file_name.txt chỉ ở cấp thư mục gốc, không áp dụng cho các thư mục con.
-> Bỏ qua tất cả các thư mục temp/ ở bất kỳ đâu trong dự án ## **/temp/ ## Bỏ qua tất cả các thư mục có tên temp ở mọi cấp độ trong dự án (từ thư mục gốc đến thư mục con).

# Giải thích các ký hiệu trong .gitignore:

-> _: Thay thế bất kỳ chuỗi ký tự nào trong tên tệp (ví dụ: _.txt sẽ bỏ qua tất cả các tệp có phần mở rộng .txt).

-> /: Đại diện cho thư mục, có thể là thư mục cấp gốc hoặc thư mục con (ví dụ: folder_name/ sẽ bỏ qua thư mục folder_name).

-> **/: Đại diện cho tất cả các thư mục và thư mục con, bất kể cấp độ (ví dụ: **/folder_name/ sẽ bỏ qua tất cả các thư mục folder_name trong toàn bộ dự án).

-> !: Bỏ qua quy tắc trước đó cho tệp hoặc thư mục đã được chỉ định, làm cho nó trở thành ngoại lệ (ví dụ: !build/config.json sẽ không bỏ qua tệp config.json trong thư mục build/).
