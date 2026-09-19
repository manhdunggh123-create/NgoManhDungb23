#include <iostream>
#include <string>
#include <iomanip>
//Luong Quoc Cuong 24810310195
using namespace std;

// CÂU 1:
struct Ngay {
    int ngay;
    int thang;
    int nam;
};

struct HangHoa {
    string maHang;
    string tenHang;
    Ngay ngayXuat;
    double giaXuat;
};

// CÂU 2:
void nhapDanhSach(HangHoa ds[], int n) {
    for (int i = 0; i < n; i++) {
        cout << "\n--- Nhap thong tin hang hoa thu " << i + 1 << " ---" << endl;
        cout << "Ma hang hoa: ";cin >> ds[i].maHang;
        cin.ignore();
        cout << "Ten hang hoa: ";getline(cin, ds[i].tenHang);
        cout << "Ngay xuat hang (ngay thang nam): ";
        cin >> ds[i].ngayXuat.ngay >> ds[i].ngayXuat.thang >> ds[i].ngayXuat.nam;
        cout << "Gia xuat hang (trieu dong): ";
        cin >> ds[i].giaXuat;
    }
}

// CÂU 3:
void xuatDanhSach(HangHoa ds[], int n) {
    cout << "\n" << left 
         << setw(12) << "Ma HH" 
         << setw(25) << "Ten Hang Hoa" 
         << setw(15) << "Ngay Xuat" 
         << setw(15) << "Gia (Trieu DF)" << endl;
    cout << string(67, '-') << endl;

    for (int i = 0; i < n; i++) {
        cout << left << setw(12) << ds[i].maHang << setw(25) << ds[i].tenHang;
        cout << right << setw(2) << ds[i].ngayXuat.ngay << "/" << setw(2) << ds[i].ngayXuat.thang << "/" << left << setw(9) << ds[i].ngayXuat.nam;
        cout << fixed << setprecision(2) << setw(15) << ds[i].giaXuat << endl;
    }
}

// CÂU 4:
void selectionSort(HangHoa ds[], int n) {
    for (int i = 0; i < n - 1; i++) {
        int minIdx = i;
        for (int j = i + 1; j < n; j++) {
            if (ds[j].giaXuat < ds[minIdx].giaXuat) {
                minIdx = j;
            }
        }
        if (minIdx != i) {
            HangHoa temp = ds[i];
            ds[i] = ds[minIdx];
            ds[minIdx] = temp;
        }
    }
}

// CÂU 5:
void timKiemNhiPhan(HangHoa ds[], int n, double X) {
    int left = 0, right = n - 1;
    int foundIdx = -1;
    while (left <= right) {
        int mid = left + (right - left) / 2;
        if (ds[mid].giaXuat == X) {
            foundIdx = mid;
            break;
        } else if (ds[mid].giaXuat < X) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    if (foundIdx == -1) {
        cout << "\nKhong tim thay hang hoa nao co gia xuat bang " << X << " trieu dong." << endl;
        return;
    }

    int first = foundIdx;
    while (first > 0 && ds[first - 1].giaXuat == X) {
        first--;
    }
    int last = foundIdx;
    while (last < n - 1 && ds[last + 1].giaXuat == X) {
        last++;
    }
    cout << "\n=== KET QUA TIM KIEM HANG HOA CO GIA = " << X << " TRIEU DONG ===";
    xuatDanhSach(&ds[first], last - first + 1);
}

// CÂU 6:
int main() {
    int n;
    cout << "Nhap so luong hang hoa: ";
    cin >> n;
    if (n <= 0) {
        cout << "So luong hang hoa khong hop le!" << endl;
        return 0;
    }
    HangHoa ds[100];
    nhapDanhSach(ds, n);
    cout << "\n=== DANH SACH HANG HOA VUA NHAP ===";
    xuatDanhSach(ds, n);
    
    selectionSort(ds, n);
    cout << "\n=== DANH SACH SAU KHI SAP XEP TANG DAN THEO GIA ===";
    xuatDanhSach(ds, n);
    
    double X;
    cout << "\nNhap gia xuat hang X can tim (trieu dong): ";
    cin >> X;
    timKiemNhiPhan(ds, n, X);
    return 0;
}
