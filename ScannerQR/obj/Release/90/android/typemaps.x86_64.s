	.file	"typemaps.x86_64.s"

/* map_module_count: START */
	.section	.rodata.map_module_count,"a",@progbits
	.type	map_module_count, @object
	.p2align	2
	.global	map_module_count
map_module_count:
	.size	map_module_count, 4
	.long	17
/* map_module_count: END */

/* java_type_count: START */
	.section	.rodata.java_type_count,"a",@progbits
	.type	java_type_count, @object
	.p2align	2
	.global	java_type_count
java_type_count:
	.size	java_type_count, 4
	.long	833
/* java_type_count: END */

/* java_name_width: START */
	.section	.rodata.java_name_width,"a",@progbits
	.type	java_name_width, @object
	.p2align	2
	.global	java_name_width
java_name_width:
	.size	java_name_width, 4
	.long	89
/* java_name_width: END */

	.include	"typemaps.shared.inc"
	.include	"typemaps.x86_64-managed.inc"

/* Managed to Java map: START */
	.section	.data.rel.map_modules,"aw",@progbits
	.type	map_modules, @object
	.p2align	4
	.global	map_modules
map_modules:
	/* module_uuid: 814d4312-b881-4247-be0f-85dc10ddfe57 */
	.byte	0x12, 0x43, 0x4d, 0x81, 0x81, 0xb8, 0x47, 0x42, 0xbe, 0x0f, 0x85, 0xdc, 0x10, 0xdd, 0xfe, 0x57
	/* entry_count */
	.long	18
	/* duplicate_count */
	.long	1
	/* map */
	.quad	module0_managed_to_java
	/* duplicate_map */
	.quad	module0_managed_to_java_duplicates
	/* assembly_name: Microsoft.AppCenter.Analytics.Android.Bindings */
	.quad	.L.map_aname.0
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 7c8f6314-c019-4c0e-ae3d-5e8b63a999d1 */
	.byte	0x14, 0x63, 0x8f, 0x7c, 0x19, 0xc0, 0x0e, 0x4c, 0xae, 0x3d, 0x5e, 0x8b, 0x63, 0xa9, 0x99, 0xd1
	/* entry_count */
	.long	1
	/* duplicate_count */
	.long	0
	/* map */
	.quad	module1_managed_to_java
	/* duplicate_map */
	.quad	0
	/* assembly_name: Microsoft.AppCenter.Crashes */
	.quad	.L.map_aname.1
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 5b459123-67cc-484d-8df8-7210de5e32a8 */
	.byte	0x23, 0x91, 0x45, 0x5b, 0xcc, 0x67, 0x4d, 0x48, 0x8d, 0xf8, 0x72, 0x10, 0xde, 0x5e, 0x32, 0xa8
	/* entry_count */
	.long	9
	/* duplicate_count */
	.long	3
	/* map */
	.quad	module2_managed_to_java
	/* duplicate_map */
	.quad	module2_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.Fragment */
	.quad	.L.map_aname.2
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 0d469737-7cab-4b5d-9e93-be53a4f30d70 */
	.byte	0x37, 0x97, 0x46, 0x0d, 0xab, 0x7c, 0x5d, 0x4b, 0x9e, 0x93, 0xbe, 0x53, 0xa4, 0xf3, 0x0d, 0x70
	/* entry_count */
	.long	3
	/* duplicate_count */
	.long	0
	/* map */
	.quad	module3_managed_to_java
	/* duplicate_map */
	.quad	0
	/* assembly_name: Xamarin.Android.Support.DrawerLayout */
	.quad	.L.map_aname.3
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: b8133439-8cc7-4079-a9a3-fd61f42c670b */
	.byte	0x39, 0x34, 0x13, 0xb8, 0xc7, 0x8c, 0x79, 0x40, 0xa9, 0xa3, 0xfd, 0x61, 0xf4, 0x2c, 0x67, 0x0b
	/* entry_count */
	.long	5
	/* duplicate_count */
	.long	1
	/* map */
	.quad	module4_managed_to_java
	/* duplicate_map */
	.quad	module4_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.Loader */
	.quad	.L.map_aname.4
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 71e9f95d-a1e6-4e57-87b6-5649b381657f */
	.byte	0x5d, 0xf9, 0xe9, 0x71, 0xe6, 0xa1, 0x57, 0x4e, 0x87, 0xb6, 0x56, 0x49, 0xb3, 0x81, 0x65, 0x7f
	/* entry_count */
	.long	2
	/* duplicate_count */
	.long	0
	/* map */
	.quad	module5_managed_to_java
	/* duplicate_map */
	.quad	0
	/* assembly_name: Microsoft.AppCenter */
	.quad	.L.map_aname.5
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: d0906070-920c-4ebd-a390-173ac972b67c */
	.byte	0x70, 0x60, 0x90, 0xd0, 0x0c, 0x92, 0xbd, 0x4e, 0xa3, 0x90, 0x17, 0x3a, 0xc9, 0x72, 0xb6, 0x7c
	/* entry_count */
	.long	2
	/* duplicate_count */
	.long	1
	/* map */
	.quad	module6_managed_to_java
	/* duplicate_map */
	.quad	module6_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Arch.Lifecycle.LiveData.Core */
	.quad	.L.map_aname.6
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 85fb4275-7576-46f0-9cf0-a8af35b9f4d8 */
	.byte	0x75, 0x42, 0xfb, 0x85, 0x76, 0x75, 0xf0, 0x46, 0x9c, 0xf0, 0xa8, 0xaf, 0x35, 0xb9, 0xf4, 0xd8
	/* entry_count */
	.long	21
	/* duplicate_count */
	.long	2
	/* map */
	.quad	module7_managed_to_java
	/* duplicate_map */
	.quad	module7_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.Compat */
	.quad	.L.map_aname.7
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: b19a229d-bc59-47dd-93eb-5c88a4fe3047 */
	.byte	0x9d, 0x22, 0x9a, 0xb1, 0x59, 0xbc, 0xdd, 0x47, 0x93, 0xeb, 0x5c, 0x88, 0xa4, 0xfe, 0x30, 0x47
	/* entry_count */
	.long	30
	/* duplicate_count */
	.long	4
	/* map */
	.quad	module8_managed_to_java
	/* duplicate_map */
	.quad	module8_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.v7.AppCompat */
	.quad	.L.map_aname.8
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 16079b9d-b234-4886-87d6-b4d2b4cde63e */
	.byte	0x9d, 0x9b, 0x07, 0x16, 0x34, 0xb2, 0x86, 0x48, 0x87, 0xd6, 0xb4, 0xd2, 0xb4, 0xcd, 0xe6, 0x3e
	/* entry_count */
	.long	1
	/* duplicate_count */
	.long	0
	/* map */
	.quad	module9_managed_to_java
	/* duplicate_map */
	.quad	0
	/* assembly_name: Xamarin.Essentials */
	.quad	.L.map_aname.9
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 6ab406c2-7f04-4088-b058-2ed5df66c238 */
	.byte	0xc2, 0x06, 0xb4, 0x6a, 0x04, 0x7f, 0x88, 0x40, 0xb0, 0x58, 0x2e, 0xd5, 0xdf, 0x66, 0xc2, 0x38
	/* entry_count */
	.long	4
	/* duplicate_count */
	.long	1
	/* map */
	.quad	module10_managed_to_java
	/* duplicate_map */
	.quad	module10_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Arch.Lifecycle.Common */
	.quad	.L.map_aname.10
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 83a9cbc3-fe28-48b4-8468-572beca4f69a */
	.byte	0xc3, 0xcb, 0xa9, 0x83, 0x28, 0xfe, 0xb4, 0x48, 0x84, 0x68, 0x57, 0x2b, 0xec, 0xa4, 0xf6, 0x9a
	/* entry_count */
	.long	207
	/* duplicate_count */
	.long	7
	/* map */
	.quad	module11_managed_to_java
	/* duplicate_map */
	.quad	module11_managed_to_java_duplicates
	/* assembly_name: DeviceAPI */
	.quad	.L.map_aname.11
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 874d5dce-f385-40dd-9a55-e6181aa142c4 */
	.byte	0xce, 0x5d, 0x4d, 0x87, 0x85, 0xf3, 0xdd, 0x40, 0x9a, 0x55, 0xe6, 0x18, 0x1a, 0xa1, 0x42, 0xc4
	/* entry_count */
	.long	105
	/* duplicate_count */
	.long	0
	/* map */
	.quad	module12_managed_to_java
	/* duplicate_map */
	.quad	0
	/* assembly_name: ScannerQR */
	.quad	.L.map_aname.12
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 45ac7ecf-dfe1-4895-9bd3-c57df3e99631 */
	.byte	0xcf, 0x7e, 0xac, 0x45, 0xe1, 0xdf, 0x95, 0x48, 0x9b, 0xd3, 0xc5, 0x7d, 0xf3, 0xe9, 0x96, 0x31
	/* entry_count */
	.long	97
	/* duplicate_count */
	.long	6
	/* map */
	.quad	module13_managed_to_java
	/* duplicate_map */
	.quad	module13_managed_to_java_duplicates
	/* assembly_name: Microsoft.AppCenter.Android.Bindings */
	.quad	.L.map_aname.13
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 8b0cddd3-1eec-4a15-8c5c-4ec67434f57d */
	.byte	0xd3, 0xdd, 0x0c, 0x8b, 0xec, 0x1e, 0x15, 0x4a, 0x8c, 0x5c, 0x4e, 0xc6, 0x74, 0x34, 0xf5, 0x7d
	/* entry_count */
	.long	309
	/* duplicate_count */
	.long	56
	/* map */
	.quad	module14_managed_to_java
	/* duplicate_map */
	.quad	module14_managed_to_java_duplicates
	/* assembly_name: Mono.Android */
	.quad	.L.map_aname.14
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: e4048fd9-f99b-4e68-ab20-4fc1fb513337 */
	.byte	0xd9, 0x8f, 0x04, 0xe4, 0x9b, 0xf9, 0x68, 0x4e, 0xab, 0x20, 0x4f, 0xc1, 0xfb, 0x51, 0x33, 0x37
	/* entry_count */
	.long	2
	/* duplicate_count */
	.long	0
	/* map */
	.quad	module15_managed_to_java
	/* duplicate_map */
	.quad	0
	/* assembly_name: Xamarin.Android.Arch.Lifecycle.ViewModel */
	.quad	.L.map_aname.15
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 7208ecf8-d776-4a08-9cd6-a544748cc737 */
	.byte	0xf8, 0xec, 0x08, 0x72, 0x76, 0xd7, 0x08, 0x4a, 0x9c, 0xd6, 0xa5, 0x44, 0x74, 0x8c, 0xc7, 0x37
	/* entry_count */
	.long	17
	/* duplicate_count */
	.long	2
	/* map */
	.quad	module16_managed_to_java
	/* duplicate_map */
	.quad	module16_managed_to_java_duplicates
	/* assembly_name: Microsoft.AppCenter.Crashes.Android.Bindings */
	.quad	.L.map_aname.16
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	.size	map_modules, 1224
/* Managed to Java map: END */

/* Java to managed map: START */
	.section	.rodata.map_java,"a",@progbits
	.type	map_java, @object
	.p2align	4
	.global	map_java
map_java:
	/* #0 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554825
	/* java_name */
	.ascii	"android/animation/Animator"
	.zero	63

	/* #1 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554827
	/* java_name */
	.ascii	"android/animation/Animator$AnimatorListener"
	.zero	46

	/* #2 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554829
	/* java_name */
	.ascii	"android/animation/Animator$AnimatorPauseListener"
	.zero	41

	/* #3 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554831
	/* java_name */
	.ascii	"android/animation/AnimatorListenerAdapter"
	.zero	48

	/* #4 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554834
	/* java_name */
	.ascii	"android/animation/TimeInterpolator"
	.zero	55

	/* #5 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554836
	/* java_name */
	.ascii	"android/app/Activity"
	.zero	69

	/* #6 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554837
	/* java_name */
	.ascii	"android/app/AlertDialog"
	.zero	66

	/* #7 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554838
	/* java_name */
	.ascii	"android/app/AlertDialog$Builder"
	.zero	58

	/* #8 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554839
	/* java_name */
	.ascii	"android/app/Application"
	.zero	66

	/* #9 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554841
	/* java_name */
	.ascii	"android/app/Application$ActivityLifecycleCallbacks"
	.zero	39

	/* #10 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554842
	/* java_name */
	.ascii	"android/app/DatePickerDialog"
	.zero	61

	/* #11 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554844
	/* java_name */
	.ascii	"android/app/DatePickerDialog$OnDateSetListener"
	.zero	43

	/* #12 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554845
	/* java_name */
	.ascii	"android/app/Dialog"
	.zero	71

	/* #13 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554851
	/* java_name */
	.ascii	"android/app/DialogFragment"
	.zero	63

	/* #14 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554852
	/* java_name */
	.ascii	"android/app/Fragment"
	.zero	69

	/* #15 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554846
	/* java_name */
	.ascii	"android/app/FragmentManager"
	.zero	62

	/* #16 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554854
	/* java_name */
	.ascii	"android/app/PendingIntent"
	.zero	64

	/* #17 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554847
	/* java_name */
	.ascii	"android/app/ProgressDialog"
	.zero	63

	/* #18 */
	/* module_index */
	.long	10
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"android/arch/lifecycle/Lifecycle"
	.zero	57

	/* #19 */
	/* module_index */
	.long	10
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"android/arch/lifecycle/Lifecycle$State"
	.zero	51

	/* #20 */
	/* module_index */
	.long	10
	/* type_token_id */
	.long	33554438
	/* java_name */
	.ascii	"android/arch/lifecycle/LifecycleObserver"
	.zero	49

	/* #21 */
	/* module_index */
	.long	10
	/* type_token_id */
	.long	33554440
	/* java_name */
	.ascii	"android/arch/lifecycle/LifecycleOwner"
	.zero	52

	/* #22 */
	/* module_index */
	.long	6
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"android/arch/lifecycle/LiveData"
	.zero	58

	/* #23 */
	/* module_index */
	.long	6
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"android/arch/lifecycle/Observer"
	.zero	58

	/* #24 */
	/* module_index */
	.long	15
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"android/arch/lifecycle/ViewModelStore"
	.zero	52

	/* #25 */
	/* module_index */
	.long	15
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"android/arch/lifecycle/ViewModelStoreOwner"
	.zero	47

	/* #26 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554822
	/* java_name */
	.ascii	"android/bluetooth/BluetoothDevice"
	.zero	56

	/* #27 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554823
	/* java_name */
	.ascii	"android/bluetooth/BluetoothGattCharacteristic"
	.zero	44

	/* #28 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554824
	/* java_name */
	.ascii	"android/bluetooth/BluetoothGattService"
	.zero	51

	/* #29 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554859
	/* java_name */
	.ascii	"android/content/BroadcastReceiver"
	.zero	56

	/* #30 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554866
	/* java_name */
	.ascii	"android/content/ComponentCallbacks"
	.zero	55

	/* #31 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554868
	/* java_name */
	.ascii	"android/content/ComponentCallbacks2"
	.zero	54

	/* #32 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554861
	/* java_name */
	.ascii	"android/content/ComponentName"
	.zero	60

	/* #33 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554856
	/* java_name */
	.ascii	"android/content/Context"
	.zero	66

	/* #34 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554863
	/* java_name */
	.ascii	"android/content/ContextWrapper"
	.zero	59

	/* #35 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554878
	/* java_name */
	.ascii	"android/content/DialogInterface"
	.zero	58

	/* #36 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554870
	/* java_name */
	.ascii	"android/content/DialogInterface$OnCancelListener"
	.zero	41

	/* #37 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554872
	/* java_name */
	.ascii	"android/content/DialogInterface$OnClickListener"
	.zero	42

	/* #38 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554876
	/* java_name */
	.ascii	"android/content/DialogInterface$OnDismissListener"
	.zero	40

	/* #39 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554857
	/* java_name */
	.ascii	"android/content/Intent"
	.zero	67

	/* #40 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554879
	/* java_name */
	.ascii	"android/content/IntentFilter"
	.zero	61

	/* #41 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554880
	/* java_name */
	.ascii	"android/content/IntentSender"
	.zero	61

	/* #42 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554886
	/* java_name */
	.ascii	"android/content/SharedPreferences"
	.zero	56

	/* #43 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554882
	/* java_name */
	.ascii	"android/content/SharedPreferences$Editor"
	.zero	49

	/* #44 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554884
	/* java_name */
	.ascii	"android/content/SharedPreferences$OnSharedPreferenceChangeListener"
	.zero	23

	/* #45 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554888
	/* java_name */
	.ascii	"android/content/pm/PackageInfo"
	.zero	59

	/* #46 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554890
	/* java_name */
	.ascii	"android/content/pm/PackageManager"
	.zero	56

	/* #47 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554894
	/* java_name */
	.ascii	"android/content/res/AssetManager"
	.zero	57

	/* #48 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554895
	/* java_name */
	.ascii	"android/content/res/ColorStateList"
	.zero	55

	/* #49 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554896
	/* java_name */
	.ascii	"android/content/res/Configuration"
	.zero	56

	/* #50 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554897
	/* java_name */
	.ascii	"android/content/res/Resources"
	.zero	60

	/* #51 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554898
	/* java_name */
	.ascii	"android/content/res/Resources$Theme"
	.zero	54

	/* #52 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554586
	/* java_name */
	.ascii	"android/database/DataSetObserver"
	.zero	57

	/* #53 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554805
	/* java_name */
	.ascii	"android/graphics/Bitmap"
	.zero	66

	/* #54 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554806
	/* java_name */
	.ascii	"android/graphics/Canvas"
	.zero	66

	/* #55 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554809
	/* java_name */
	.ascii	"android/graphics/ColorFilter"
	.zero	61

	/* #56 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554811
	/* java_name */
	.ascii	"android/graphics/Matrix"
	.zero	66

	/* #57 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554812
	/* java_name */
	.ascii	"android/graphics/Paint"
	.zero	67

	/* #58 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554813
	/* java_name */
	.ascii	"android/graphics/Point"
	.zero	67

	/* #59 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554814
	/* java_name */
	.ascii	"android/graphics/PorterDuff"
	.zero	62

	/* #60 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554815
	/* java_name */
	.ascii	"android/graphics/PorterDuff$Mode"
	.zero	57

	/* #61 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554816
	/* java_name */
	.ascii	"android/graphics/Rect"
	.zero	68

	/* #62 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554817
	/* java_name */
	.ascii	"android/graphics/RectF"
	.zero	67

	/* #63 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554818
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable"
	.zero	55

	/* #64 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554820
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable$Callback"
	.zero	46

	/* #65 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554803
	/* java_name */
	.ascii	"android/hardware/usb/UsbDevice"
	.zero	59

	/* #66 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554801
	/* java_name */
	.ascii	"android/media/SoundPool"
	.zero	66

	/* #67 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554797
	/* java_name */
	.ascii	"android/net/ConnectivityManager"
	.zero	58

	/* #68 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554798
	/* java_name */
	.ascii	"android/net/NetworkInfo"
	.zero	66

	/* #69 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554799
	/* java_name */
	.ascii	"android/net/Uri"
	.zero	74

	/* #70 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/os/AsyncTask"
	.zero	69

	/* #71 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554785
	/* java_name */
	.ascii	"android/os/BaseBundle"
	.zero	68

	/* #72 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554786
	/* java_name */
	.ascii	"android/os/Build"
	.zero	73

	/* #73 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554787
	/* java_name */
	.ascii	"android/os/Build$VERSION"
	.zero	65

	/* #74 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554789
	/* java_name */
	.ascii	"android/os/Bundle"
	.zero	72

	/* #75 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554782
	/* java_name */
	.ascii	"android/os/Handler"
	.zero	71

	/* #76 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554794
	/* java_name */
	.ascii	"android/os/Looper"
	.zero	72

	/* #77 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554795
	/* java_name */
	.ascii	"android/os/Parcel"
	.zero	72

	/* #78 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554793
	/* java_name */
	.ascii	"android/os/Parcelable"
	.zero	68

	/* #79 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554791
	/* java_name */
	.ascii	"android/os/Parcelable$Creator"
	.zero	60

	/* #80 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554780
	/* java_name */
	.ascii	"android/preference/PreferenceManager"
	.zero	53

	/* #81 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554945
	/* java_name */
	.ascii	"android/runtime/JavaProxyThrowable"
	.zero	55

	/* #82 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"android/support/v13/view/DragAndDropPermissionsCompat"
	.zero	36

	/* #83 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554461
	/* java_name */
	.ascii	"android/support/v4/app/ActivityCompat"
	.zero	52

	/* #84 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554463
	/* java_name */
	.ascii	"android/support/v4/app/ActivityCompat$OnRequestPermissionsResultCallback"
	.zero	17

	/* #85 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554465
	/* java_name */
	.ascii	"android/support/v4/app/ActivityCompat$PermissionCompatDelegate"
	.zero	27

	/* #86 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554467
	/* java_name */
	.ascii	"android/support/v4/app/ActivityCompat$RequestPermissionsRequestCodeValidator"
	.zero	13

	/* #87 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"android/support/v4/app/Fragment"
	.zero	58

	/* #88 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"android/support/v4/app/Fragment$SavedState"
	.zero	47

	/* #89 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"android/support/v4/app/FragmentActivity"
	.zero	50

	/* #90 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554438
	/* java_name */
	.ascii	"android/support/v4/app/FragmentManager"
	.zero	51

	/* #91 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554440
	/* java_name */
	.ascii	"android/support/v4/app/FragmentManager$BackStackEntry"
	.zero	36

	/* #92 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554441
	/* java_name */
	.ascii	"android/support/v4/app/FragmentManager$FragmentLifecycleCallbacks"
	.zero	24

	/* #93 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554444
	/* java_name */
	.ascii	"android/support/v4/app/FragmentManager$OnBackStackChangedListener"
	.zero	24

	/* #94 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554449
	/* java_name */
	.ascii	"android/support/v4/app/FragmentTransaction"
	.zero	47

	/* #95 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554440
	/* java_name */
	.ascii	"android/support/v4/app/LoaderManager"
	.zero	53

	/* #96 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554442
	/* java_name */
	.ascii	"android/support/v4/app/LoaderManager$LoaderCallbacks"
	.zero	37

	/* #97 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554468
	/* java_name */
	.ascii	"android/support/v4/app/SharedElementCallback"
	.zero	45

	/* #98 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554470
	/* java_name */
	.ascii	"android/support/v4/app/SharedElementCallback$OnSharedElementsReadyListener"
	.zero	15

	/* #99 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554472
	/* java_name */
	.ascii	"android/support/v4/app/TaskStackBuilder"
	.zero	50

	/* #100 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554474
	/* java_name */
	.ascii	"android/support/v4/app/TaskStackBuilder$SupportParentable"
	.zero	32

	/* #101 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554459
	/* java_name */
	.ascii	"android/support/v4/content/ContextCompat"
	.zero	49

	/* #102 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"android/support/v4/content/Loader"
	.zero	56

	/* #103 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"android/support/v4/content/Loader$OnLoadCanceledListener"
	.zero	33

	/* #104 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554439
	/* java_name */
	.ascii	"android/support/v4/content/Loader$OnLoadCompleteListener"
	.zero	33

	/* #105 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554460
	/* java_name */
	.ascii	"android/support/v4/content/pm/PackageInfoCompat"
	.zero	42

	/* #106 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554456
	/* java_name */
	.ascii	"android/support/v4/internal/view/SupportMenu"
	.zero	45

	/* #107 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554458
	/* java_name */
	.ascii	"android/support/v4/internal/view/SupportMenuItem"
	.zero	41

	/* #108 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"android/support/v4/view/ActionProvider"
	.zero	51

	/* #109 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554438
	/* java_name */
	.ascii	"android/support/v4/view/ActionProvider$SubUiVisibilityListener"
	.zero	27

	/* #110 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554442
	/* java_name */
	.ascii	"android/support/v4/view/ActionProvider$VisibilityListener"
	.zero	32

	/* #111 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554454
	/* java_name */
	.ascii	"android/support/v4/view/ViewPropertyAnimatorCompat"
	.zero	39

	/* #112 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554451
	/* java_name */
	.ascii	"android/support/v4/view/ViewPropertyAnimatorListener"
	.zero	37

	/* #113 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554453
	/* java_name */
	.ascii	"android/support/v4/view/ViewPropertyAnimatorUpdateListener"
	.zero	31

	/* #114 */
	/* module_index */
	.long	3
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"android/support/v4/widget/DrawerLayout"
	.zero	51

	/* #115 */
	/* module_index */
	.long	3
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"android/support/v4/widget/DrawerLayout$DrawerListener"
	.zero	36

	/* #116 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar"
	.zero	57

	/* #117 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$LayoutParams"
	.zero	44

	/* #118 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554439
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$OnMenuVisibilityListener"
	.zero	32

	/* #119 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554443
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$OnNavigationListener"
	.zero	36

	/* #120 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554444
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$Tab"
	.zero	53

	/* #121 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554447
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$TabListener"
	.zero	45

	/* #122 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554451
	/* java_name */
	.ascii	"android/support/v7/app/ActionBarDrawerToggle"
	.zero	45

	/* #123 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554453
	/* java_name */
	.ascii	"android/support/v7/app/ActionBarDrawerToggle$Delegate"
	.zero	36

	/* #124 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554455
	/* java_name */
	.ascii	"android/support/v7/app/ActionBarDrawerToggle$DelegateProvider"
	.zero	28

	/* #125 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554456
	/* java_name */
	.ascii	"android/support/v7/app/AppCompatActivity"
	.zero	49

	/* #126 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554460
	/* java_name */
	.ascii	"android/support/v7/app/AppCompatCallback"
	.zero	49

	/* #127 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554457
	/* java_name */
	.ascii	"android/support/v7/app/AppCompatDelegate"
	.zero	49

	/* #128 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"android/support/v7/graphics/drawable/DrawerArrowDrawable"
	.zero	33

	/* #129 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554474
	/* java_name */
	.ascii	"android/support/v7/view/ActionMode"
	.zero	55

	/* #130 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554476
	/* java_name */
	.ascii	"android/support/v7/view/ActionMode$Callback"
	.zero	46

	/* #131 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554478
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuBuilder"
	.zero	49

	/* #132 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554480
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuBuilder$Callback"
	.zero	40

	/* #133 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554487
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuItemImpl"
	.zero	48

	/* #134 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554484
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuPresenter"
	.zero	47

	/* #135 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554482
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuPresenter$Callback"
	.zero	38

	/* #136 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554486
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuView"
	.zero	52

	/* #137 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554488
	/* java_name */
	.ascii	"android/support/v7/view/menu/SubMenuBuilder"
	.zero	46

	/* #138 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554471
	/* java_name */
	.ascii	"android/support/v7/widget/DecorToolbar"
	.zero	51

	/* #139 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554472
	/* java_name */
	.ascii	"android/support/v7/widget/ScrollingTabContainerView"
	.zero	38

	/* #140 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554473
	/* java_name */
	.ascii	"android/support/v7/widget/ScrollingTabContainerView$VisibilityAnimListener"
	.zero	15

	/* #141 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554461
	/* java_name */
	.ascii	"android/support/v7/widget/Toolbar"
	.zero	56

	/* #142 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554465
	/* java_name */
	.ascii	"android/support/v7/widget/Toolbar$OnMenuItemClickListener"
	.zero	32

	/* #143 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554462
	/* java_name */
	.ascii	"android/support/v7/widget/Toolbar_NavigationOnClickEventDispatcher"
	.zero	23

	/* #144 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554762
	/* java_name */
	.ascii	"android/text/Editable"
	.zero	68

	/* #145 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554765
	/* java_name */
	.ascii	"android/text/GetChars"
	.zero	68

	/* #146 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554768
	/* java_name */
	.ascii	"android/text/InputFilter"
	.zero	65

	/* #147 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554770
	/* java_name */
	.ascii	"android/text/NoCopySpan"
	.zero	66

	/* #148 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554772
	/* java_name */
	.ascii	"android/text/Spannable"
	.zero	67

	/* #149 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554775
	/* java_name */
	.ascii	"android/text/Spanned"
	.zero	69

	/* #150 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554778
	/* java_name */
	.ascii	"android/text/TextWatcher"
	.zero	65

	/* #151 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554759
	/* java_name */
	.ascii	"android/util/AttributeSet"
	.zero	64

	/* #152 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554757
	/* java_name */
	.ascii	"android/util/DisplayMetrics"
	.zero	62

	/* #153 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554756
	/* java_name */
	.ascii	"android/util/Log"
	.zero	73

	/* #154 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554760
	/* java_name */
	.ascii	"android/util/SparseArray"
	.zero	65

	/* #155 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554685
	/* java_name */
	.ascii	"android/view/ActionMode"
	.zero	66

	/* #156 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554687
	/* java_name */
	.ascii	"android/view/ActionMode$Callback"
	.zero	57

	/* #157 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554690
	/* java_name */
	.ascii	"android/view/ActionProvider"
	.zero	62

	/* #158 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554699
	/* java_name */
	.ascii	"android/view/ContextMenu"
	.zero	65

	/* #159 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554697
	/* java_name */
	.ascii	"android/view/ContextMenu$ContextMenuInfo"
	.zero	49

	/* #160 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554692
	/* java_name */
	.ascii	"android/view/ContextThemeWrapper"
	.zero	57

	/* #161 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554693
	/* java_name */
	.ascii	"android/view/Display"
	.zero	69

	/* #162 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554694
	/* java_name */
	.ascii	"android/view/DragEvent"
	.zero	67

	/* #163 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554708
	/* java_name */
	.ascii	"android/view/InputEvent"
	.zero	66

	/* #164 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554666
	/* java_name */
	.ascii	"android/view/KeyEvent"
	.zero	68

	/* #165 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554668
	/* java_name */
	.ascii	"android/view/KeyEvent$Callback"
	.zero	59

	/* #166 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554669
	/* java_name */
	.ascii	"android/view/LayoutInflater"
	.zero	62

	/* #167 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554671
	/* java_name */
	.ascii	"android/view/LayoutInflater$Factory"
	.zero	54

	/* #168 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554673
	/* java_name */
	.ascii	"android/view/LayoutInflater$Factory2"
	.zero	53

	/* #169 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554701
	/* java_name */
	.ascii	"android/view/Menu"
	.zero	72

	/* #170 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554728
	/* java_name */
	.ascii	"android/view/MenuInflater"
	.zero	64

	/* #171 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554707
	/* java_name */
	.ascii	"android/view/MenuItem"
	.zero	68

	/* #172 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554703
	/* java_name */
	.ascii	"android/view/MenuItem$OnActionExpandListener"
	.zero	45

	/* #173 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554705
	/* java_name */
	.ascii	"android/view/MenuItem$OnMenuItemClickListener"
	.zero	44

	/* #174 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554674
	/* java_name */
	.ascii	"android/view/MotionEvent"
	.zero	65

	/* #175 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554731
	/* java_name */
	.ascii	"android/view/SearchEvent"
	.zero	65

	/* #176 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554711
	/* java_name */
	.ascii	"android/view/SubMenu"
	.zero	69

	/* #177 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554734
	/* java_name */
	.ascii	"android/view/Surface"
	.zero	69

	/* #178 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554715
	/* java_name */
	.ascii	"android/view/SurfaceHolder"
	.zero	63

	/* #179 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554713
	/* java_name */
	.ascii	"android/view/SurfaceHolder$Callback"
	.zero	54

	/* #180 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554646
	/* java_name */
	.ascii	"android/view/View"
	.zero	72

	/* #181 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554648
	/* java_name */
	.ascii	"android/view/View$OnClickListener"
	.zero	56

	/* #182 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554651
	/* java_name */
	.ascii	"android/view/View$OnCreateContextMenuListener"
	.zero	44

	/* #183 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554653
	/* java_name */
	.ascii	"android/view/View$OnFocusChangeListener"
	.zero	50

	/* #184 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554657
	/* java_name */
	.ascii	"android/view/View$OnKeyListener"
	.zero	58

	/* #185 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554738
	/* java_name */
	.ascii	"android/view/ViewGroup"
	.zero	67

	/* #186 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554739
	/* java_name */
	.ascii	"android/view/ViewGroup$LayoutParams"
	.zero	54

	/* #187 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554740
	/* java_name */
	.ascii	"android/view/ViewGroup$MarginLayoutParams"
	.zero	48

	/* #188 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554717
	/* java_name */
	.ascii	"android/view/ViewManager"
	.zero	65

	/* #189 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554719
	/* java_name */
	.ascii	"android/view/ViewParent"
	.zero	66

	/* #190 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554742
	/* java_name */
	.ascii	"android/view/ViewPropertyAnimator"
	.zero	56

	/* #191 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554675
	/* java_name */
	.ascii	"android/view/ViewTreeObserver"
	.zero	60

	/* #192 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554677
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnGlobalLayoutListener"
	.zero	37

	/* #193 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554679
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnPreDrawListener"
	.zero	42

	/* #194 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554681
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnTouchModeChangeListener"
	.zero	34

	/* #195 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554682
	/* java_name */
	.ascii	"android/view/Window"
	.zero	70

	/* #196 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554684
	/* java_name */
	.ascii	"android/view/Window$Callback"
	.zero	61

	/* #197 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554722
	/* java_name */
	.ascii	"android/view/WindowManager"
	.zero	63

	/* #198 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554720
	/* java_name */
	.ascii	"android/view/WindowManager$LayoutParams"
	.zero	50

	/* #199 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554749
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityEvent"
	.zero	44

	/* #200 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554755
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityEventSource"
	.zero	38

	/* #201 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554750
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityRecord"
	.zero	43

	/* #202 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554745
	/* java_name */
	.ascii	"android/view/animation/Animation"
	.zero	57

	/* #203 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554748
	/* java_name */
	.ascii	"android/view/animation/Interpolator"
	.zero	54

	/* #204 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554588
	/* java_name */
	.ascii	"android/widget/AbsListView"
	.zero	63

	/* #205 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554616
	/* java_name */
	.ascii	"android/widget/AbsSpinner"
	.zero	64

	/* #206 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554631
	/* java_name */
	.ascii	"android/widget/Adapter"
	.zero	67

	/* #207 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554590
	/* java_name */
	.ascii	"android/widget/AdapterView"
	.zero	63

	/* #208 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554592
	/* java_name */
	.ascii	"android/widget/AdapterView$OnItemClickListener"
	.zero	43

	/* #209 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554596
	/* java_name */
	.ascii	"android/widget/AdapterView$OnItemLongClickListener"
	.zero	39

	/* #210 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554600
	/* java_name */
	.ascii	"android/widget/AdapterView$OnItemSelectedListener"
	.zero	40

	/* #211 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/widget/ArrayAdapter"
	.zero	62

	/* #212 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554620
	/* java_name */
	.ascii	"android/widget/BaseAdapter"
	.zero	63

	/* #213 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554622
	/* java_name */
	.ascii	"android/widget/Button"
	.zero	68

	/* #214 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554612
	/* java_name */
	.ascii	"android/widget/DatePicker"
	.zero	64

	/* #215 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554614
	/* java_name */
	.ascii	"android/widget/DatePicker$OnDateChangedListener"
	.zero	42

	/* #216 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554623
	/* java_name */
	.ascii	"android/widget/EditText"
	.zero	66

	/* #217 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554624
	/* java_name */
	.ascii	"android/widget/Filter"
	.zero	68

	/* #218 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554626
	/* java_name */
	.ascii	"android/widget/Filter$FilterListener"
	.zero	53

	/* #219 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554633
	/* java_name */
	.ascii	"android/widget/Filterable"
	.zero	64

	/* #220 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554628
	/* java_name */
	.ascii	"android/widget/FrameLayout"
	.zero	63

	/* #221 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554629
	/* java_name */
	.ascii	"android/widget/HorizontalScrollView"
	.zero	54

	/* #222 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554636
	/* java_name */
	.ascii	"android/widget/ImageView"
	.zero	65

	/* #223 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554635
	/* java_name */
	.ascii	"android/widget/ListAdapter"
	.zero	63

	/* #224 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554641
	/* java_name */
	.ascii	"android/widget/ListView"
	.zero	66

	/* #225 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554642
	/* java_name */
	.ascii	"android/widget/ProgressBar"
	.zero	63

	/* #226 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554643
	/* java_name */
	.ascii	"android/widget/Spinner"
	.zero	67

	/* #227 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554638
	/* java_name */
	.ascii	"android/widget/SpinnerAdapter"
	.zero	60

	/* #228 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554615
	/* java_name */
	.ascii	"android/widget/TextView"
	.zero	66

	/* #229 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554640
	/* java_name */
	.ascii	"android/widget/ThemedSpinnerAdapter"
	.zero	54

	/* #230 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554644
	/* java_name */
	.ascii	"android/widget/Toast"
	.zero	69

	/* #231 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554723
	/* java_name */
	.ascii	"com/barcode/BarcodeUtility"
	.zero	63

	/* #232 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554724
	/* java_name */
	.ascii	"com/barcode/BarcodeUtility$ModuleType"
	.zero	52

	/* #233 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554717
	/* java_name */
	.ascii	"com/custom/Barcode2DSoftHuace"
	.zero	60

	/* #234 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554718
	/* java_name */
	.ascii	"com/custom/Barcode2DSoftHuace$Barcode2DScanCallback"
	.zero	38

	/* #235 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554719
	/* java_name */
	.ascii	"com/custom/Barcode2DSoftHuace$Barcode2DScanCallback2"
	.zero	37

	/* #236 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554721
	/* java_name */
	.ascii	"com/custom/BarcodeScanCallback"
	.zero	59

	/* #237 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554722
	/* java_name */
	.ascii	"com/custom/RFIDWithUHFUARTUAE"
	.zero	60

	/* #238 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554678
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeOptions"
	.zero	60

	/* #239 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554692
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeResult"
	.zero	61

	/* #240 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554695
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeWindowing"
	.zero	58

	/* #241 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554696
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeWindowing$DecodeWindow"
	.zero	45

	/* #242 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554697
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeWindowing$DecodeWindowLimits"
	.zero	39

	/* #243 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554698
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeWindowing$DecodeWindowMode"
	.zero	41

	/* #244 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554699
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeWindowing$DecodeWindowShowWindow"
	.zero	35

	/* #245 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554679
	/* java_name */
	.ascii	"com/hsm/barcode/Decoder"
	.zero	66

	/* #246 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554684
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues"
	.zero	54

	/* #247 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554685
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$EngineID"
	.zero	45

	/* #248 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554686
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$EngineType"
	.zero	43

	/* #249 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554687
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$LightsMode"
	.zero	43

	/* #250 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554688
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$OCRMode"
	.zero	46

	/* #251 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554689
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$OCRTemplate"
	.zero	42

	/* #252 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554690
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$SymbologyFlags"
	.zero	39

	/* #253 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554691
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$SymbologyID"
	.zero	42

	/* #254 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554693
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderException"
	.zero	57

	/* #255 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554694
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderException$ResultID"
	.zero	48

	/* #256 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554708
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderListener"
	.zero	58

	/* #257 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554700
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues"
	.zero	59

	/* #258 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554701
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues$ExposureMethod"
	.zero	44

	/* #259 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554702
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues$ExposureMode"
	.zero	46

	/* #260 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554703
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues$ExposureSettings"
	.zero	42

	/* #261 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554704
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues$ExposureSettingsMinMax"
	.zero	36

	/* #262 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554705
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues$SpecularExclusion"
	.zero	41

	/* #263 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554706
	/* java_name */
	.ascii	"com/hsm/barcode/HalInterface"
	.zero	61

	/* #264 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554714
	/* java_name */
	.ascii	"com/hsm/barcode/IQImagingProperties"
	.zero	54

	/* #265 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554715
	/* java_name */
	.ascii	"com/hsm/barcode/IQImagingProperties$IQImageFormat"
	.zero	40

	/* #266 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554712
	/* java_name */
	.ascii	"com/hsm/barcode/ImageAttributes"
	.zero	58

	/* #267 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554713
	/* java_name */
	.ascii	"com/hsm/barcode/ImagerProperties"
	.zero	57

	/* #268 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554716
	/* java_name */
	.ascii	"com/hsm/barcode/SymbologyConfig"
	.zero	58

	/* #269 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554672
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/AEData"
	.zero	53

	/* #270 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554673
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/DetailData"
	.zero	49

	/* #271 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554674
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/Result"
	.zero	53

	/* #272 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554675
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/SaveMode"
	.zero	51

	/* #273 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554676
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/SymbologyData"
	.zero	46

	/* #274 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554677
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/SymbologySettingItem"
	.zero	39

	/* #275 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"com/microsoft/appcenter/AbstractAppCenterService"
	.zero	41

	/* #276 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"com/microsoft/appcenter/AppCenter"
	.zero	56

	/* #277 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554445
	/* java_name */
	.ascii	"com/microsoft/appcenter/AppCenterHandler"
	.zero	49

	/* #278 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554447
	/* java_name */
	.ascii	"com/microsoft/appcenter/AppCenterService"
	.zero	49

	/* #279 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554440
	/* java_name */
	.ascii	"com/microsoft/appcenter/BuildConfig"
	.zero	54

	/* #280 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554441
	/* java_name */
	.ascii	"com/microsoft/appcenter/CancellationException"
	.zero	44

	/* #281 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554442
	/* java_name */
	.ascii	"com/microsoft/appcenter/Constants"
	.zero	56

	/* #282 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554438
	/* java_name */
	.ascii	"com/microsoft/appcenter/CustomProperties"
	.zero	49

	/* #283 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554439
	/* java_name */
	.ascii	"com/microsoft/appcenter/DependencyConfiguration"
	.zero	42

	/* #284 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554443
	/* java_name */
	.ascii	"com/microsoft/appcenter/Flags"
	.zero	60

	/* #285 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/Analytics"
	.zero	46

	/* #286 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/AnalyticsTransmissionTarget"
	.zero	28

	/* #287 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/AuthenticationProvider"
	.zero	33

	/* #288 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554439
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/AuthenticationProvider$AuthenticationCallback"
	.zero	10

	/* #289 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554441
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/AuthenticationProvider$TokenProvider"
	.zero	19

	/* #290 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554442
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/AuthenticationProvider$Type"
	.zero	28

	/* #291 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554443
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/BuildConfig"
	.zero	44

	/* #292 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554444
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/EventProperties"
	.zero	40

	/* #293 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554445
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/PropertyConfigurator"
	.zero	35

	/* #294 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554454
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/channel/AnalyticsListener"
	.zero	30

	/* #295 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554452
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/channel/AnalyticsValidator"
	.zero	29

	/* #296 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554459
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/channel/SessionTracker"
	.zero	33

	/* #297 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554446
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/ingestion/models/EventLog"
	.zero	30

	/* #298 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554447
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/ingestion/models/LogWithNameAndProperties"
	.zero	14

	/* #299 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554449
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/ingestion/models/PageLog"
	.zero	31

	/* #300 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554450
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/ingestion/models/StartSessionLog"
	.zero	23

	/* #301 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554451
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/ingestion/models/one/CommonSchemaEventLog"
	.zero	14

	/* #302 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554553
	/* java_name */
	.ascii	"com/microsoft/appcenter/channel/AbstractChannelListener"
	.zero	34

	/* #303 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554573
	/* java_name */
	.ascii	"com/microsoft/appcenter/channel/Channel"
	.zero	50

	/* #304 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554555
	/* java_name */
	.ascii	"com/microsoft/appcenter/channel/Channel$GroupListener"
	.zero	36

	/* #305 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554561
	/* java_name */
	.ascii	"com/microsoft/appcenter/channel/Channel$Listener"
	.zero	41

	/* #306 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554574
	/* java_name */
	.ascii	"com/microsoft/appcenter/channel/OneCollectorChannelListener"
	.zero	30

	/* #307 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/AbstractCrashesListener"
	.zero	34

	/* #308 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554438
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/BuildConfig"
	.zero	46

	/* #309 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/Crashes"
	.zero	50

	/* #310 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554440
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/CrashesListener"
	.zero	42

	/* #311 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554448
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/WrapperSdkExceptionManager"
	.zero	31

	/* #312 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554453
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/AbstractErrorLog"
	.zero	24

	/* #313 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554455
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/ErrorAttachmentLog"
	.zero	22

	/* #314 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554456
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/Exception"
	.zero	31

	/* #315 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554457
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/HandledErrorLog"
	.zero	25

	/* #316 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554458
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/ManagedErrorLog"
	.zero	25

	/* #317 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554459
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/StackFrame"
	.zero	30

	/* #318 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554460
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/Thread"
	.zero	34

	/* #319 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554450
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/model/ErrorReport"
	.zero	40

	/* #320 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554452
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/model/NativeException"
	.zero	36

	/* #321 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554451
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/model/TestCrashException"
	.zero	33

	/* #322 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554449
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/utils/ErrorLogHelper"
	.zero	37

	/* #323 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554548
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/HttpClient"
	.zero	50

	/* #324 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554546
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/HttpClient$CallTemplate"
	.zero	37

	/* #325 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554543
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/HttpException"
	.zero	47

	/* #326 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554544
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/HttpResponse"
	.zero	48

	/* #327 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554550
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/ServiceCall"
	.zero	49

	/* #328 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554552
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/ServiceCallback"
	.zero	45

	/* #329 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554489
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/AppCenterIngestion"
	.zero	37

	/* #330 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554491
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/Ingestion"
	.zero	46

	/* #331 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554492
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/OneCollectorIngestion"
	.zero	34

	/* #332 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554493
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/AbstractLog"
	.zero	37

	/* #333 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554495
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/CommonProperties"
	.zero	32

	/* #334 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554496
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/CustomPropertiesLog"
	.zero	29

	/* #335 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554497
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/Device"
	.zero	42

	/* #336 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554499
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/Log"
	.zero	45

	/* #337 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554502
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/LogContainer"
	.zero	36

	/* #338 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554503
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/LogWithProperties"
	.zero	31

	/* #339 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554501
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/Model"
	.zero	43

	/* #340 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554505
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/StartServiceLog"
	.zero	33

	/* #341 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554506
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/WrapperSdk"
	.zero	38

	/* #342 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554530
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/AbstractLogFactory"
	.zero	25

	/* #343 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554532
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/CustomPropertiesLogFactory"
	.zero	17

	/* #344 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554533
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/DefaultLogSerializer"
	.zero	23

	/* #345 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554540
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/JSONDateUtils"
	.zero	30

	/* #346 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554541
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/JSONUtils"
	.zero	34

	/* #347 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554535
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/LogFactory"
	.zero	33

	/* #348 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554537
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/LogSerializer"
	.zero	30

	/* #349 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554539
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/ModelFactory"
	.zero	31

	/* #350 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554542
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/StartServiceLogFactory"
	.zero	21

	/* #351 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554515
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/AppExtension"
	.zero	32

	/* #352 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554516
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/CommonSchemaDataUtils"
	.zero	23

	/* #353 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554517
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/CommonSchemaLog"
	.zero	29

	/* #354 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554519
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/Data"
	.zero	40

	/* #355 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554520
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/DeviceExtension"
	.zero	29

	/* #356 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554521
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/Extensions"
	.zero	34

	/* #357 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554522
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/LocExtension"
	.zero	32

	/* #358 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554523
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/MetadataExtension"
	.zero	27

	/* #359 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554524
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/NetExtension"
	.zero	32

	/* #360 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554525
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/OsExtension"
	.zero	33

	/* #361 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554526
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/PartAUtils"
	.zero	34

	/* #362 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554527
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/ProtocolExtension"
	.zero	27

	/* #363 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554528
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/SdkExtension"
	.zero	32

	/* #364 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554529
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/UserExtension"
	.zero	31

	/* #365 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554507
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/BooleanTypedProperty"
	.zero	17

	/* #366 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554508
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/DateTimeTypedProperty"
	.zero	16

	/* #367 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554509
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/DoubleTypedProperty"
	.zero	18

	/* #368 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554510
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/LongTypedProperty"
	.zero	20

	/* #369 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554511
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/StringTypedProperty"
	.zero	18

	/* #370 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554512
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/TypedProperty"
	.zero	24

	/* #371 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554514
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/TypedPropertyUtils"
	.zero	19

	/* #372 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554448
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/AppCenterLog"
	.zero	47

	/* #373 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554449
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/AppNameHelper"
	.zero	46

	/* #374 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554450
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/ApplicationLifecycleListener"
	.zero	31

	/* #375 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554452
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/ApplicationLifecycleListener$ApplicationLifecycleCallbacks"
	.zero	1

	/* #376 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554453
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/AsyncTaskUtils"
	.zero	45

	/* #377 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554454
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/DeviceInfoHelper"
	.zero	43

	/* #378 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554455
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/DeviceInfoHelper$DeviceInfoException"
	.zero	23

	/* #379 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554456
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/HandlerUtils"
	.zero	47

	/* #380 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554457
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/HashUtils"
	.zero	50

	/* #381 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554458
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/IdHelper"
	.zero	51

	/* #382 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554459
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/InstrumentationRegistryHelper"
	.zero	30

	/* #383 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554460
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/NetworkStateHelper"
	.zero	41

	/* #384 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554462
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/NetworkStateHelper$Listener"
	.zero	32

	/* #385 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554465
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/PrefStorageConstants"
	.zero	39

	/* #386 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554466
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/ShutdownHelper"
	.zero	45

	/* #387 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554467
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/TicketCache"
	.zero	48

	/* #388 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554486
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/async/AppCenterConsumer"
	.zero	36

	/* #389 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554488
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/async/AppCenterFuture"
	.zero	38

	/* #390 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554484
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/async/DefaultAppCenterFuture"
	.zero	31

	/* #391 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554477
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/context/SessionContext"
	.zero	37

	/* #392 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554478
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/context/SessionContext$SessionInfo"
	.zero	25

	/* #393 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554479
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/context/UserIdContext"
	.zero	38

	/* #394 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554481
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/context/UserIdContext$Listener"
	.zero	29

	/* #395 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554468
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils"
	.zero	41

	/* #396 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554469
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils$CryptoHandlerEntry"
	.zero	22

	/* #397 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554470
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils$DecryptedData"
	.zero	27

	/* #398 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554472
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils$ICipher"
	.zero	33

	/* #399 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554474
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils$ICryptoFactory"
	.zero	26

	/* #400 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554476
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils$IKeyGenerator"
	.zero	27

	/* #401 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554488
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation"
	.zero	57

	/* #402 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554490
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$BDLocationListener"
	.zero	38

	/* #403 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554494
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$BDProviderEnum"
	.zero	42

	/* #404 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554495
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$BDStartModeEnum"
	.zero	41

	/* #405 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554497
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$BDStatusListener"
	.zero	40

	/* #406 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554504
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$ReadThread"
	.zero	46

	/* #407 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554506
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$TestResultRawData"
	.zero	39

	/* #408 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554486
	/* java_name */
	.ascii	"com/rscja/deviceapi/Barcode1D"
	.zero	60

	/* #409 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554487
	/* java_name */
	.ascii	"com/rscja/deviceapi/Barcode2D"
	.zero	60

	/* #410 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554520
	/* java_name */
	.ascii	"com/rscja/deviceapi/BluetoothReader"
	.zero	54

	/* #411 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554522
	/* java_name */
	.ascii	"com/rscja/deviceapi/BluetoothReader$DataCallBack"
	.zero	41

	/* #412 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554524
	/* java_name */
	.ascii	"com/rscja/deviceapi/BluetoothReader$OnDataChangeListener"
	.zero	33

	/* #413 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554529
	/* java_name */
	.ascii	"com/rscja/deviceapi/CardWithBYL"
	.zero	58

	/* #414 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554530
	/* java_name */
	.ascii	"com/rscja/deviceapi/Device"
	.zero	63

	/* #415 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554532
	/* java_name */
	.ascii	"com/rscja/deviceapi/DeviceAPI"
	.zero	60

	/* #416 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554533
	/* java_name */
	.ascii	"com/rscja/deviceapi/DeviceConfiguration"
	.zero	50

	/* #417 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554534
	/* java_name */
	.ascii	"com/rscja/deviceapi/DeviceConfiguration$DeviceInfo"
	.zero	39

	/* #418 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554535
	/* java_name */
	.ascii	"com/rscja/deviceapi/Fingerprint"
	.zero	58

	/* #419 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554536
	/* java_name */
	.ascii	"com/rscja/deviceapi/Fingerprint$BufferEnum"
	.zero	47

	/* #420 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554537
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS"
	.zero	50

	/* #421 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554538
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$DataFormat"
	.zero	39

	/* #422 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554540
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$EnrollCallBack"
	.zero	35

	/* #423 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554541
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$FingerprintInfo"
	.zero	34

	/* #424 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554543
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$GRABCallBack"
	.zero	37

	/* #425 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554545
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$IdentificationCallBack"
	.zero	27

	/* #426 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554547
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$PtCaptureCallBack"
	.zero	32

	/* #427 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554549
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$TemplateVerifyCallBack"
	.zero	27

	/* #428 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554550
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$ThreadEnroll"
	.zero	37

	/* #429 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554551
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$ThreadGRAB"
	.zero	39

	/* #430 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554552
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$ThreadIdentification"
	.zero	29

	/* #431 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554553
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$ThreadPtCapture"
	.zero	34

	/* #432 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554554
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$ThreadTemplateVerify"
	.zero	29

	/* #433 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554555
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho"
	.zero	48

	/* #434 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554557
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$EnrollCallBack"
	.zero	33

	/* #435 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554559
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$IdentificationCallBack"
	.zero	25

	/* #436 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554560
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$MorphoMessage"
	.zero	34

	/* #437 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554562
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$PtCaptureCallBack"
	.zero	30

	/* #438 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554564
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$TemplateVerifyCallBack"
	.zero	25

	/* #439 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554565
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$ThreadEnroll"
	.zero	35

	/* #440 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554566
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$ThreadIdentification"
	.zero	27

	/* #441 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554567
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$ThreadPtCapture"
	.zero	32

	/* #442 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554568
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$ThreadPtCapturePKComp"
	.zero	26

	/* #443 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554569
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$ThreadTemplateVerify"
	.zero	27

	/* #444 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554570
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$TimeOutThread"
	.zero	34

	/* #445 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554571
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithZAZ"
	.zero	51

	/* #446 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554572
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithZAZ$BufferEnum"
	.zero	40

	/* #447 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554573
	/* java_name */
	.ascii	"com/rscja/deviceapi/Infrared"
	.zero	61

	/* #448 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554574
	/* java_name */
	.ascii	"com/rscja/deviceapi/LedLight"
	.zero	61

	/* #449 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554575
	/* java_name */
	.ascii	"com/rscja/deviceapi/Module"
	.zero	63

	/* #450 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554582
	/* java_name */
	.ascii	"com/rscja/deviceapi/PSAM"
	.zero	65

	/* #451 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554576
	/* java_name */
	.ascii	"com/rscja/deviceapi/Printer"
	.zero	62

	/* #452 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554577
	/* java_name */
	.ascii	"com/rscja/deviceapi/Printer$BarcodeType"
	.zero	50

	/* #453 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554578
	/* java_name */
	.ascii	"com/rscja/deviceapi/Printer$MeesageThread"
	.zero	48

	/* #454 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554579
	/* java_name */
	.ascii	"com/rscja/deviceapi/Printer$PrinterStatus"
	.zero	48

	/* #455 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554581
	/* java_name */
	.ascii	"com/rscja/deviceapi/Printer$PrinterStatusCallBack"
	.zero	40

	/* #456 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554583
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDBase"
	.zero	61

	/* #457 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554584
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A"
	.zero	52

	/* #458 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554585
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A$DESFireEncryptionTypekEnum"
	.zero	25

	/* #459 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554586
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A$DESFireFileTypekEnum"
	.zero	31

	/* #460 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554587
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A$KeyType"
	.zero	44

	/* #461 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554588
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A$TagType"
	.zero	44

	/* #462 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554589
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A4CPU"
	.zero	48

	/* #463 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554590
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443B"
	.zero	52

	/* #464 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554591
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO15693"
	.zero	53

	/* #465 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554592
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO15693$TagType"
	.zero	45

	/* #466 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554593
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithLF"
	.zero	59

	/* #467 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554594
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF"
	.zero	58

	/* #468 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554595
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF$BankEnum"
	.zero	49

	/* #469 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554596
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF$LockModeEnum"
	.zero	45

	/* #470 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554597
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF$SingelModeEnum"
	.zero	43

	/* #471 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554598
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF$SingleModeEnum"
	.zero	43

	/* #472 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554599
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF706"
	.zero	55

	/* #473 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554600
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFA8"
	.zero	56

	/* #474 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554601
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFA8$NotifyThread"
	.zero	43

	/* #475 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554602
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBLE"
	.zero	55

	/* #476 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554604
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth"
	.zero	49

	/* #477 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554606
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$BTStatusCallback"
	.zero	32

	/* #478 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554607
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$BankEnum"
	.zero	40

	/* #479 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554608
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$DataReceiveBTData"
	.zero	31

	/* #480 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554610
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$KeyEventCallback"
	.zero	32

	/* #481 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554612
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$ScanBTCallback"
	.zero	34

	/* #482 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554613
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$StatusEnum"
	.zero	38

	/* #483 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554614
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFUART"
	.zero	54

	/* #484 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554616
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFUSB"
	.zero	55

	/* #485 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554618
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFUSB$UsbReceiver"
	.zero	43

	/* #486 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554621
	/* java_name */
	.ascii	"com/rscja/deviceapi/SPI"
	.zero	66

	/* #487 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554619
	/* java_name */
	.ascii	"com/rscja/deviceapi/ScanerLedLight"
	.zero	55

	/* #488 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554620
	/* java_name */
	.ascii	"com/rscja/deviceapi/ScanerLedLight$OffTask"
	.zero	47

	/* #489 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554622
	/* java_name */
	.ascii	"com/rscja/deviceapi/UHFCustomAPI"
	.zero	57

	/* #490 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554623
	/* java_name */
	.ascii	"com/rscja/deviceapi/UHFProtocolParse"
	.zero	53

	/* #491 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554624
	/* java_name */
	.ascii	"com/rscja/deviceapi/UHFProtocolParseUSB"
	.zero	50

	/* #492 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554625
	/* java_name */
	.ascii	"com/rscja/deviceapi/VersionInfo"
	.zero	58

	/* #493 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554665
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/AnimalEntity"
	.zero	50

	/* #494 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554666
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/BDLocation"
	.zero	52

	/* #495 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554667
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/DESFireFile"
	.zero	51

	/* #496 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554668
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/ISO15693Entity"
	.zero	48

	/* #497 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554669
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/SatelliteEntity"
	.zero	47

	/* #498 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554670
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/SimpleRFIDEntity"
	.zero	46

	/* #499 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554671
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/UHFTAGInfo"
	.zero	52

	/* #500 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554654
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/ConfigurationException"
	.zero	37

	/* #501 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554655
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/DeviceNotConnectException"
	.zero	34

	/* #502 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554656
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/FingerprintAlreadyEnrolledException"
	.zero	24

	/* #503 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554657
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/FingerprintInvalidIDException"
	.zero	30

	/* #504 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554660
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/PSAMException"
	.zero	46

	/* #505 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554658
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/PrinterBarcodeInvalidException"
	.zero	29

	/* #506 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554659
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/PrinterLowPager"
	.zero	44

	/* #507 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554661
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/RFIDArgumentException"
	.zero	38

	/* #508 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554662
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/RFIDNotFoundException"
	.zero	38

	/* #509 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554663
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/RFIDReadFailureException"
	.zero	35

	/* #510 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554664
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/RFIDVerificationException"
	.zero	34

	/* #511 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554635
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/ConnectionStatus"
	.zero	42

	/* #512 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554641
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/ConnectionStatusCallback"
	.zero	34

	/* #513 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554636
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/IBluetoothReader"
	.zero	42

	/* #514 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554646
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/IUHF"
	.zero	54

	/* #515 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554651
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/IUHFProtocolParse"
	.zero	41

	/* #516 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554653
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/IUhfReader"
	.zero	48

	/* #517 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554643
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/KeyEventCallback"
	.zero	42

	/* #518 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554645
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/ScanBTCallback"
	.zero	44

	/* #519 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554629
	/* java_name */
	.ascii	"com/rscja/deviceapi/service/BLEService"
	.zero	51

	/* #520 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554631
	/* java_name */
	.ascii	"com/rscja/deviceapi/service/BLEService$IDataCallBack"
	.zero	37

	/* #521 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554632
	/* java_name */
	.ascii	"com/rscja/deviceapi/service/BTService"
	.zero	52

	/* #522 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554634
	/* java_name */
	.ascii	"com/rscja/deviceapi/service/BTService$IDataCallBack"
	.zero	38

	/* #523 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554626
	/* java_name */
	.ascii	"com/rscja/deviceapi/usb/USBUtil"
	.zero	58

	/* #524 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554627
	/* java_name */
	.ascii	"com/rscja/deviceapi/usb/USBUtil$ReceiverData"
	.zero	45

	/* #525 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554628
	/* java_name */
	.ascii	"com/rscja/deviceapi/usb/USBUtil$UsbReceiver"
	.zero	46

	/* #526 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554485
	/* java_name */
	.ascii	"com/rscja/utility/StringUtility"
	.zero	58

	/* #527 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554479
	/* java_name */
	.ascii	"com/scanner/IScanner"
	.zero	69

	/* #528 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554483
	/* java_name */
	.ascii	"com/scanner/utility/ScannerUtility"
	.zero	55

	/* #529 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554450
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader"
	.zero	54

	/* #530 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554452
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$AutoFocusCallback"
	.zero	36

	/* #531 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554454
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$DecodeCallback"
	.zero	39

	/* #532 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554456
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$ErrorCallback"
	.zero	40

	/* #533 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554457
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$EventHandler"
	.zero	41

	/* #534 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554459
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$OnZoomChangeListener"
	.zero	33

	/* #535 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554462
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$ParamNum"
	.zero	45

	/* #536 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554463
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$ParamVal"
	.zero	45

	/* #537 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554464
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$Parameters"
	.zero	43

	/* #538 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554466
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$PictureCallback"
	.zero	38

	/* #539 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554468
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$PreviewCallback"
	.zero	38

	/* #540 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554469
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$PropertyNum"
	.zero	42

	/* #541 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554470
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$ReaderInfo"
	.zero	43

	/* #542 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554471
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$Size"
	.zero	49

	/* #543 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554473
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$VideoCallback"
	.zero	40

	/* #544 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft"
	.zero	50

	/* #545 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$CODETYPE"
	.zero	41

	/* #546 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$HardwareType"
	.zero	37

	/* #547 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554439
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$PictureCallback"
	.zero	34

	/* #548 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554440
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ResultDataBroadcastReceiver"
	.zero	22

	/* #549 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554442
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ScanCallback"
	.zero	37

	/* #550 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554443
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ScanerParamNum"
	.zero	35

	/* #551 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554444
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ScanerParamVal"
	.zero	35

	/* #552 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554445
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ScanerPropertyNum"
	.zero	32

	/* #553 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554446
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ThreadGC"
	.zero	41

	/* #554 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554447
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ThreadScan"
	.zero	39

	/* #555 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554449
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$VideoCallback"
	.zero	36

	/* #556 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554476
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Config"
	.zero	61

	/* #557 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554477
	/* java_name */
	.ascii	"com/zebra/adc/decoder/SymbologyConfiguration"
	.zero	45

	/* #558 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554478
	/* java_name */
	.ascii	"com/zebra/adc/decoder/SymbologyConfiguration$BarcodeSymbologyID"
	.zero	26

	/* #559 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554545
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/CheckStockAddonAdapter"
	.zero	45

	/* #560 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554549
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/InterWarehouseEnteredPositionViewAdapter"
	.zero	27

	/* #561 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554550
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/InterwarehousSerialOrSCCCEntryAdapter"
	.zero	30

	/* #562 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554552
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/IssuedEnterAdapter"
	.zero	49

	/* #563 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554557
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/ProductionEnteredPositionViewAdapter"
	.zero	31

	/* #564 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554558
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/ProductionSerialOrSSCCAdapter"
	.zero	38

	/* #565 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554560
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/TakeOverEnteredPositionsViewAdapter"
	.zero	32

	/* #566 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554562
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/TakeOverIdentAdapter"
	.zero	47

	/* #567 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554564
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/TakeOverSerialOrSSCCEntryAdapter"
	.zero	35

	/* #568 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554577
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/UnfinishedInterwarehouseAdapter"
	.zero	36

	/* #569 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554566
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/UnfinishedIssuedAdapter"
	.zero	44

	/* #570 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554568
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/UnfinishedPackagingAdapter"
	.zero	41

	/* #571 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554570
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/UnfinishedProductionAdapter"
	.zero	40

	/* #572 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554579
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/UnfinishedTakeoverAdapter"
	.zero	42

	/* #573 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554543
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/adapter"
	.zero	60

	/* #574 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554544
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/adapterListViewItem"
	.zero	48

	/* #575 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554555
	/* java_name */
	.ascii	"crc6409c71bcadc42b4aa/packagingListAdapter"
	.zero	47

	/* #576 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554456
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/CheckStock"
	.zero	57

	/* #577 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554457
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/CheckStockTablet"
	.zero	51

	/* #578 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554458
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InterWarehouseBusinessEventSetup"
	.zero	35

	/* #579 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554459
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InterWarehouseBusinessEventSetupTablet"
	.zero	29

	/* #580 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554460
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InterWarehouseEnteredPositionsView"
	.zero	33

	/* #581 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554461
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InterWarehouseEnteredPositionsViewTablet"
	.zero	27

	/* #582 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554462
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InterWarehouseSerialOrSSCCEntry"
	.zero	36

	/* #583 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554463
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InterWarehouseSerialOrSSCCEntryTablet"
	.zero	30

	/* #584 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554464
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InventoryConfirm"
	.zero	51

	/* #585 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554465
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InventoryConfirmTablet"
	.zero	45

	/* #586 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554466
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InventoryMenu"
	.zero	54

	/* #587 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554467
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InventoryOpen"
	.zero	54

	/* #588 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554468
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InventoryOpenDocument"
	.zero	46

	/* #589 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554469
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InventoryOpenDocumentTablet"
	.zero	40

	/* #590 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554470
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InventoryOpenTablet"
	.zero	48

	/* #591 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554471
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InventoryPrint"
	.zero	53

	/* #592 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554472
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InventoryPrintTablet"
	.zero	47

	/* #593 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554473
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InventoryProcess"
	.zero	51

	/* #594 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554474
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/InventoryProcessTablet"
	.zero	45

	/* #595 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554475
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/IssuedGoodsBusinessEventSetup"
	.zero	38

	/* #596 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554476
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/IssuedGoodsBusinessEventSetupTablet"
	.zero	32

	/* #597 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554477
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/IssuedGoodsEnteredPositionsView"
	.zero	36

	/* #598 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554478
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/IssuedGoodsEnteredPositionsViewTablet"
	.zero	30

	/* #599 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554479
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/IssuedGoodsIdentEntry"
	.zero	46

	/* #600 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554480
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/IssuedGoodsIdentEntryTablet"
	.zero	40

	/* #601 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554481
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/IssuedGoodsIdentEntryWithTrail"
	.zero	37

	/* #602 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554482
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/IssuedGoodsIdentEntryWithTrailTablet"
	.zero	31

	/* #603 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554483
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/IssuedGoodsSerialOrSSCCEntry"
	.zero	39

	/* #604 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554484
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/IssuedGoodsSerialOrSSCCEntryTablet"
	.zero	33

	/* #605 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554485
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/MainActivity"
	.zero	55

	/* #606 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554486
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/MainMenu"
	.zero	59

	/* #607 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554487
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PackagingEnteredPositionsView"
	.zero	38

	/* #608 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554488
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PackagingEnteredPositionsViewTablet"
	.zero	32

	/* #609 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554489
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PackagingSetContext"
	.zero	48

	/* #610 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554490
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PackagingSetContextTablet"
	.zero	42

	/* #611 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554491
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PackagingUnit"
	.zero	54

	/* #612 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554492
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PackagingUnitList"
	.zero	50

	/* #613 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554493
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PackagingUnitListTablet"
	.zero	44

	/* #614 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554494
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PackagingUnitTablet"
	.zero	48

	/* #615 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554495
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PrintingInputControl"
	.zero	47

	/* #616 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554496
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PrintingInputControlTablet"
	.zero	41

	/* #617 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554497
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PrintingMenu"
	.zero	55

	/* #618 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554498
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PrintingOutputControl"
	.zero	46

	/* #619 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554499
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PrintingOutputControlTablet"
	.zero	40

	/* #620 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554500
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PrintingProcessControl"
	.zero	45

	/* #621 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554501
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PrintingProcessControlTablet"
	.zero	39

	/* #622 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554502
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PrintingReprintLabels"
	.zero	46

	/* #623 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554503
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PrintingReprintLabelsTablet"
	.zero	40

	/* #624 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554504
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PrintingSSCCCodes"
	.zero	50

	/* #625 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554505
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/PrintingSSCCCodesTablet"
	.zero	44

	/* #626 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554506
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/ProductionCard"
	.zero	53

	/* #627 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554507
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/ProductionCardTablet"
	.zero	47

	/* #628 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554508
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/ProductionEnteredPositionsView"
	.zero	37

	/* #629 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554509
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/ProductionEnteredPositionsViewTablet"
	.zero	31

	/* #630 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554510
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/ProductionPalette"
	.zero	50

	/* #631 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554511
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/ProductionPaletteTablet"
	.zero	44

	/* #632 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554512
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/ProductionSerialOrSSCCEntry"
	.zero	40

	/* #633 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554513
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/ProductionSerialOrSSCCEntryTablet"
	.zero	34

	/* #634 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554514
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/ProductionWorkOrderSetup"
	.zero	43

	/* #635 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554515
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/ProductionWorkOrderSetupTablet"
	.zero	37

	/* #636 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554516
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/RapidTakeover"
	.zero	54

	/* #637 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554519
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/SelectSubjectBeforeFinish"
	.zero	42

	/* #638 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554520
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/SelectSubjectBeforeFinishTablet"
	.zero	36

	/* #639 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554521
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/Settings"
	.zero	59

	/* #640 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554522
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/TakeOver2Main"
	.zero	54

	/* #641 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554523
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/TakeOver2MainTablet"
	.zero	48

	/* #642 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554524
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/TakeOver2Orders"
	.zero	52

	/* #643 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554525
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/TakeOver2OrdersTablet"
	.zero	46

	/* #644 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554526
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/TakeOverBusinessEventSetup"
	.zero	41

	/* #645 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554527
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/TakeOverBusinessEventSetupTablet"
	.zero	35

	/* #646 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554528
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/TakeOverEnteredPositionsView"
	.zero	39

	/* #647 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554529
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/TakeOverEnteredPositionsViewTablet"
	.zero	33

	/* #648 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554530
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/TakeOverIdentEntry"
	.zero	49

	/* #649 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554531
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/TakeOverIdentEntryTablet"
	.zero	43

	/* #650 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554532
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/TakeOverSerialOrSSCCEntry"
	.zero	42

	/* #651 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554533
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/TakeOverSerialOrSSCCEntryTablet"
	.zero	36

	/* #652 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554534
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/UnfinishedInterWarehouseView"
	.zero	39

	/* #653 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554535
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/UnfinishedInterWarehouseViewTablet"
	.zero	33

	/* #654 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554536
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/UnfinishedIssuedGoodsView"
	.zero	42

	/* #655 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554537
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/UnfinishedIssuedGoodsViewTablet"
	.zero	36

	/* #656 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554538
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/UnfinishedProductionView"
	.zero	43

	/* #657 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554539
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/UnfinishedProductionViewTablet"
	.zero	37

	/* #658 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554540
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/UnfinishedTakeoversView"
	.zero	44

	/* #659 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554541
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/UnfinishedTakeoversViewTablet"
	.zero	38

	/* #660 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554517
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/receiver"
	.zero	59

	/* #661 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554628
	/* java_name */
	.ascii	"crc640b2286ca4f1c700f/receiver_InitTask"
	.zero	50

	/* #662 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554434
	/* java_name */
	.ascii	"crc6428c7b543d88da90c/DatePickerFragment"
	.zero	49

	/* #663 */
	/* module_index */
	.long	5
	/* type_token_id */
	.long	33554445
	/* java_name */
	.ascii	"crc64350623dcb797cc38/AndroidHttpClientAdapter"
	.zero	43

	/* #664 */
	/* module_index */
	.long	5
	/* type_token_id */
	.long	33554447
	/* java_name */
	.ascii	"crc64350623dcb797cc38/ServiceCall"
	.zero	56

	/* #665 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554455
	/* java_name */
	.ascii	"crc64626865e9f13072a9/BarcodeDataReceiver"
	.zero	48

	/* #666 */
	/* module_index */
	.long	9
	/* type_token_id */
	.long	33554448
	/* java_name */
	.ascii	"crc64a0e0a82d0db9a07d/ActivityLifecycleContextListener"
	.zero	35

	/* #667 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"crc64a4555f9f70c213ae/Crashes_AndroidCrashListener"
	.zero	39

	/* #668 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555134
	/* java_name */
	.ascii	"java/io/Closeable"
	.zero	72

	/* #669 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555130
	/* java_name */
	.ascii	"java/io/File"
	.zero	77

	/* #670 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555131
	/* java_name */
	.ascii	"java/io/FileDescriptor"
	.zero	67

	/* #671 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555132
	/* java_name */
	.ascii	"java/io/FileInputStream"
	.zero	66

	/* #672 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555136
	/* java_name */
	.ascii	"java/io/Flushable"
	.zero	72

	/* #673 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555140
	/* java_name */
	.ascii	"java/io/IOException"
	.zero	70

	/* #674 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555137
	/* java_name */
	.ascii	"java/io/InputStream"
	.zero	70

	/* #675 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555139
	/* java_name */
	.ascii	"java/io/InterruptedIOException"
	.zero	59

	/* #676 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555143
	/* java_name */
	.ascii	"java/io/OutputStream"
	.zero	69

	/* #677 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555145
	/* java_name */
	.ascii	"java/io/PrintWriter"
	.zero	70

	/* #678 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555142
	/* java_name */
	.ascii	"java/io/Serializable"
	.zero	69

	/* #679 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555146
	/* java_name */
	.ascii	"java/io/StringWriter"
	.zero	69

	/* #680 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555147
	/* java_name */
	.ascii	"java/io/Writer"
	.zero	75

	/* #681 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555085
	/* java_name */
	.ascii	"java/lang/AbstractStringBuilder"
	.zero	58

	/* #682 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555093
	/* java_name */
	.ascii	"java/lang/Appendable"
	.zero	69

	/* #683 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555095
	/* java_name */
	.ascii	"java/lang/AutoCloseable"
	.zero	66

	/* #684 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555062
	/* java_name */
	.ascii	"java/lang/Boolean"
	.zero	72

	/* #685 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555063
	/* java_name */
	.ascii	"java/lang/Byte"
	.zero	75

	/* #686 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555096
	/* java_name */
	.ascii	"java/lang/CharSequence"
	.zero	67

	/* #687 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555064
	/* java_name */
	.ascii	"java/lang/Character"
	.zero	70

	/* #688 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555065
	/* java_name */
	.ascii	"java/lang/Class"
	.zero	74

	/* #689 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555088
	/* java_name */
	.ascii	"java/lang/ClassCastException"
	.zero	61

	/* #690 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555066
	/* java_name */
	.ascii	"java/lang/ClassNotFoundException"
	.zero	57

	/* #691 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555099
	/* java_name */
	.ascii	"java/lang/Cloneable"
	.zero	70

	/* #692 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555101
	/* java_name */
	.ascii	"java/lang/Comparable"
	.zero	69

	/* #693 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555067
	/* java_name */
	.ascii	"java/lang/Double"
	.zero	73

	/* #694 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555089
	/* java_name */
	.ascii	"java/lang/Enum"
	.zero	75

	/* #695 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555091
	/* java_name */
	.ascii	"java/lang/Error"
	.zero	74

	/* #696 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555068
	/* java_name */
	.ascii	"java/lang/Exception"
	.zero	70

	/* #697 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555069
	/* java_name */
	.ascii	"java/lang/Float"
	.zero	74

	/* #698 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555104
	/* java_name */
	.ascii	"java/lang/IllegalArgumentException"
	.zero	55

	/* #699 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555105
	/* java_name */
	.ascii	"java/lang/IllegalStateException"
	.zero	58

	/* #700 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555106
	/* java_name */
	.ascii	"java/lang/IndexOutOfBoundsException"
	.zero	54

	/* #701 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555071
	/* java_name */
	.ascii	"java/lang/Integer"
	.zero	72

	/* #702 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555107
	/* java_name */
	.ascii	"java/lang/InterruptedException"
	.zero	59

	/* #703 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555103
	/* java_name */
	.ascii	"java/lang/Iterable"
	.zero	71

	/* #704 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555110
	/* java_name */
	.ascii	"java/lang/LinkageError"
	.zero	67

	/* #705 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555072
	/* java_name */
	.ascii	"java/lang/Long"
	.zero	75

	/* #706 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555111
	/* java_name */
	.ascii	"java/lang/NoClassDefFoundError"
	.zero	59

	/* #707 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555112
	/* java_name */
	.ascii	"java/lang/NullPointerException"
	.zero	59

	/* #708 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555113
	/* java_name */
	.ascii	"java/lang/Number"
	.zero	73

	/* #709 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555073
	/* java_name */
	.ascii	"java/lang/Object"
	.zero	73

	/* #710 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555115
	/* java_name */
	.ascii	"java/lang/ReflectiveOperationException"
	.zero	51

	/* #711 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555109
	/* java_name */
	.ascii	"java/lang/Runnable"
	.zero	71

	/* #712 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555074
	/* java_name */
	.ascii	"java/lang/RuntimeException"
	.zero	63

	/* #713 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555116
	/* java_name */
	.ascii	"java/lang/SecurityException"
	.zero	62

	/* #714 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555075
	/* java_name */
	.ascii	"java/lang/Short"
	.zero	74

	/* #715 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555117
	/* java_name */
	.ascii	"java/lang/StackTraceElement"
	.zero	62

	/* #716 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555076
	/* java_name */
	.ascii	"java/lang/String"
	.zero	73

	/* #717 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555078
	/* java_name */
	.ascii	"java/lang/StringBuffer"
	.zero	67

	/* #718 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555080
	/* java_name */
	.ascii	"java/lang/StringBuilder"
	.zero	66

	/* #719 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555082
	/* java_name */
	.ascii	"java/lang/Thread"
	.zero	73

	/* #720 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555084
	/* java_name */
	.ascii	"java/lang/Throwable"
	.zero	70

	/* #721 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555118
	/* java_name */
	.ascii	"java/lang/UnsupportedOperationException"
	.zero	50

	/* #722 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555119
	/* java_name */
	.ascii	"java/lang/Void"
	.zero	75

	/* #723 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555121
	/* java_name */
	.ascii	"java/lang/annotation/Annotation"
	.zero	58

	/* #724 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555123
	/* java_name */
	.ascii	"java/lang/reflect/AnnotatedElement"
	.zero	55

	/* #725 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555125
	/* java_name */
	.ascii	"java/lang/reflect/GenericDeclaration"
	.zero	53

	/* #726 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555127
	/* java_name */
	.ascii	"java/lang/reflect/Type"
	.zero	67

	/* #727 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555129
	/* java_name */
	.ascii	"java/lang/reflect/TypeVariable"
	.zero	59

	/* #728 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554988
	/* java_name */
	.ascii	"java/math/BigInteger"
	.zero	69

	/* #729 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554969
	/* java_name */
	.ascii	"java/net/ConnectException"
	.zero	64

	/* #730 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554971
	/* java_name */
	.ascii	"java/net/HttpURLConnection"
	.zero	63

	/* #731 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554973
	/* java_name */
	.ascii	"java/net/InetSocketAddress"
	.zero	63

	/* #732 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554974
	/* java_name */
	.ascii	"java/net/ProtocolException"
	.zero	63

	/* #733 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554975
	/* java_name */
	.ascii	"java/net/Proxy"
	.zero	75

	/* #734 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554976
	/* java_name */
	.ascii	"java/net/Proxy$Type"
	.zero	70

	/* #735 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554977
	/* java_name */
	.ascii	"java/net/ProxySelector"
	.zero	67

	/* #736 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554979
	/* java_name */
	.ascii	"java/net/SocketAddress"
	.zero	67

	/* #737 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554981
	/* java_name */
	.ascii	"java/net/SocketException"
	.zero	65

	/* #738 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554982
	/* java_name */
	.ascii	"java/net/SocketTimeoutException"
	.zero	58

	/* #739 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554984
	/* java_name */
	.ascii	"java/net/URI"
	.zero	77

	/* #740 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554985
	/* java_name */
	.ascii	"java/net/URL"
	.zero	77

	/* #741 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554986
	/* java_name */
	.ascii	"java/net/URLConnection"
	.zero	67

	/* #742 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554983
	/* java_name */
	.ascii	"java/net/UnknownServiceException"
	.zero	57

	/* #743 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555038
	/* java_name */
	.ascii	"java/nio/Buffer"
	.zero	74

	/* #744 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555040
	/* java_name */
	.ascii	"java/nio/ByteBuffer"
	.zero	70

	/* #745 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555045
	/* java_name */
	.ascii	"java/nio/channels/ByteChannel"
	.zero	60

	/* #746 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555047
	/* java_name */
	.ascii	"java/nio/channels/Channel"
	.zero	64

	/* #747 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555042
	/* java_name */
	.ascii	"java/nio/channels/FileChannel"
	.zero	60

	/* #748 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555049
	/* java_name */
	.ascii	"java/nio/channels/GatheringByteChannel"
	.zero	51

	/* #749 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555051
	/* java_name */
	.ascii	"java/nio/channels/InterruptibleChannel"
	.zero	51

	/* #750 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555053
	/* java_name */
	.ascii	"java/nio/channels/ReadableByteChannel"
	.zero	52

	/* #751 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555055
	/* java_name */
	.ascii	"java/nio/channels/ScatteringByteChannel"
	.zero	50

	/* #752 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555057
	/* java_name */
	.ascii	"java/nio/channels/SeekableByteChannel"
	.zero	52

	/* #753 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555059
	/* java_name */
	.ascii	"java/nio/channels/WritableByteChannel"
	.zero	52

	/* #754 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555060
	/* java_name */
	.ascii	"java/nio/channels/spi/AbstractInterruptibleChannel"
	.zero	39

	/* #755 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555020
	/* java_name */
	.ascii	"java/security/Key"
	.zero	72

	/* #756 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555023
	/* java_name */
	.ascii	"java/security/KeyStore"
	.zero	67

	/* #757 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555025
	/* java_name */
	.ascii	"java/security/KeyStore$LoadStoreParameter"
	.zero	48

	/* #758 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555027
	/* java_name */
	.ascii	"java/security/KeyStore$ProtectionParameter"
	.zero	47

	/* #759 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555022
	/* java_name */
	.ascii	"java/security/Principal"
	.zero	66

	/* #760 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555028
	/* java_name */
	.ascii	"java/security/SecureRandom"
	.zero	63

	/* #761 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555031
	/* java_name */
	.ascii	"java/security/cert/Certificate"
	.zero	59

	/* #762 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555033
	/* java_name */
	.ascii	"java/security/cert/CertificateFactory"
	.zero	52

	/* #763 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555036
	/* java_name */
	.ascii	"java/security/cert/X509Certificate"
	.zero	55

	/* #764 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555035
	/* java_name */
	.ascii	"java/security/cert/X509Extension"
	.zero	57

	/* #765 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555030
	/* java_name */
	.ascii	"java/security/spec/AlgorithmParameterSpec"
	.zero	48

	/* #766 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554989
	/* java_name */
	.ascii	"java/util/AbstractCollection"
	.zero	61

	/* #767 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554991
	/* java_name */
	.ascii	"java/util/AbstractList"
	.zero	67

	/* #768 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554993
	/* java_name */
	.ascii	"java/util/AbstractQueue"
	.zero	66

	/* #769 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554937
	/* java_name */
	.ascii	"java/util/ArrayList"
	.zero	70

	/* #770 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554926
	/* java_name */
	.ascii	"java/util/Collection"
	.zero	69

	/* #771 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554996
	/* java_name */
	.ascii	"java/util/Date"
	.zero	75

	/* #772 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555000
	/* java_name */
	.ascii	"java/util/Enumeration"
	.zero	68

	/* #773 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554928
	/* java_name */
	.ascii	"java/util/HashMap"
	.zero	72

	/* #774 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554946
	/* java_name */
	.ascii	"java/util/HashSet"
	.zero	72

	/* #775 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555002
	/* java_name */
	.ascii	"java/util/Iterator"
	.zero	71

	/* #776 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555004
	/* java_name */
	.ascii	"java/util/List"
	.zero	75

	/* #777 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555006
	/* java_name */
	.ascii	"java/util/ListIterator"
	.zero	67

	/* #778 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555008
	/* java_name */
	.ascii	"java/util/Queue"
	.zero	74

	/* #779 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555011
	/* java_name */
	.ascii	"java/util/Random"
	.zero	73

	/* #780 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555010
	/* java_name */
	.ascii	"java/util/RandomAccess"
	.zero	67

	/* #781 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555012
	/* java_name */
	.ascii	"java/util/TimerTask"
	.zero	70

	/* #782 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555014
	/* java_name */
	.ascii	"java/util/UUID"
	.zero	75

	/* #783 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555016
	/* java_name */
	.ascii	"java/util/concurrent/BlockingQueue"
	.zero	55

	/* #784 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555017
	/* java_name */
	.ascii	"java/util/concurrent/LinkedBlockingQueue"
	.zero	49

	/* #785 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555018
	/* java_name */
	.ascii	"java/util/concurrent/TimeUnit"
	.zero	60

	/* #786 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554563
	/* java_name */
	.ascii	"javax/net/SocketFactory"
	.zero	66

	/* #787 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554568
	/* java_name */
	.ascii	"javax/net/ssl/HostnameVerifier"
	.zero	59

	/* #788 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554565
	/* java_name */
	.ascii	"javax/net/ssl/HttpsURLConnection"
	.zero	57

	/* #789 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554570
	/* java_name */
	.ascii	"javax/net/ssl/KeyManager"
	.zero	65

	/* #790 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554579
	/* java_name */
	.ascii	"javax/net/ssl/KeyManagerFactory"
	.zero	58

	/* #791 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554580
	/* java_name */
	.ascii	"javax/net/ssl/SSLContext"
	.zero	65

	/* #792 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554572
	/* java_name */
	.ascii	"javax/net/ssl/SSLSession"
	.zero	65

	/* #793 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554574
	/* java_name */
	.ascii	"javax/net/ssl/SSLSessionContext"
	.zero	58

	/* #794 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554581
	/* java_name */
	.ascii	"javax/net/ssl/SSLSocketFactory"
	.zero	59

	/* #795 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554576
	/* java_name */
	.ascii	"javax/net/ssl/TrustManager"
	.zero	63

	/* #796 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554583
	/* java_name */
	.ascii	"javax/net/ssl/TrustManagerFactory"
	.zero	56

	/* #797 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554578
	/* java_name */
	.ascii	"javax/net/ssl/X509TrustManager"
	.zero	59

	/* #798 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554559
	/* java_name */
	.ascii	"javax/security/cert/Certificate"
	.zero	58

	/* #799 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554561
	/* java_name */
	.ascii	"javax/security/cert/X509Certificate"
	.zero	54

	/* #800 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555170
	/* java_name */
	.ascii	"mono/android/TypeManager"
	.zero	65

	/* #801 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554874
	/* java_name */
	.ascii	"mono/android/content/DialogInterface_OnClickListenerImplementor"
	.zero	26

	/* #802 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554921
	/* java_name */
	.ascii	"mono/android/runtime/InputStreamAdapter"
	.zero	50

	/* #803 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"mono/android/runtime/JavaArray"
	.zero	59

	/* #804 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554943
	/* java_name */
	.ascii	"mono/android/runtime/JavaObject"
	.zero	58

	/* #805 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554961
	/* java_name */
	.ascii	"mono/android/runtime/OutputStreamAdapter"
	.zero	49

	/* #806 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554445
	/* java_name */
	.ascii	"mono/android/support/v4/app/FragmentManager_OnBackStackChangedListenerImplementor"
	.zero	8

	/* #807 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554440
	/* java_name */
	.ascii	"mono/android/support/v4/view/ActionProvider_SubUiVisibilityListenerImplementor"
	.zero	11

	/* #808 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554444
	/* java_name */
	.ascii	"mono/android/support/v4/view/ActionProvider_VisibilityListenerImplementor"
	.zero	16

	/* #809 */
	/* module_index */
	.long	3
	/* type_token_id */
	.long	33554442
	/* java_name */
	.ascii	"mono/android/support/v4/widget/DrawerLayout_DrawerListenerImplementor"
	.zero	20

	/* #810 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554441
	/* java_name */
	.ascii	"mono/android/support/v7/app/ActionBar_OnMenuVisibilityListenerImplementor"
	.zero	16

	/* #811 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554467
	/* java_name */
	.ascii	"mono/android/support/v7/widget/Toolbar_OnMenuItemClickListenerImplementor"
	.zero	16

	/* #812 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554649
	/* java_name */
	.ascii	"mono/android/view/View_OnClickListenerImplementor"
	.zero	40

	/* #813 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554655
	/* java_name */
	.ascii	"mono/android/view/View_OnFocusChangeListenerImplementor"
	.zero	34

	/* #814 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554659
	/* java_name */
	.ascii	"mono/android/view/View_OnKeyListenerImplementor"
	.zero	42

	/* #815 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554594
	/* java_name */
	.ascii	"mono/android/widget/AdapterView_OnItemClickListenerImplementor"
	.zero	27

	/* #816 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554598
	/* java_name */
	.ascii	"mono/android/widget/AdapterView_OnItemLongClickListenerImplementor"
	.zero	23

	/* #817 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554603
	/* java_name */
	.ascii	"mono/android/widget/AdapterView_OnItemSelectedListenerImplementor"
	.zero	24

	/* #818 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554711
	/* java_name */
	.ascii	"mono/com/hsm/barcode/DecoderListenerImplementor"
	.zero	42

	/* #819 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554458
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/analytics/channel/AnalyticsListenerImplementor"
	.zero	14

	/* #820 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554559
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/channel/Channel_GroupListenerImplementor"
	.zero	20

	/* #821 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554571
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/channel/Channel_ListenerImplementor"
	.zero	25

	/* #822 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554447
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/crashes/CrashesListenerImplementor"
	.zero	26

	/* #823 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554464
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/utils/NetworkStateHelper_ListenerImplementor"
	.zero	16

	/* #824 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554483
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/utils/context/UserIdContext_ListenerImplementor"
	.zero	13

	/* #825 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554493
	/* java_name */
	.ascii	"mono/com/rscja/deviceapi/BDNavigation_BDLocationListenerImplementor"
	.zero	22

	/* #826 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554503
	/* java_name */
	.ascii	"mono/com/rscja/deviceapi/BDNavigation_BDStatusListenerImplementor"
	.zero	24

	/* #827 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554526
	/* java_name */
	.ascii	"mono/com/rscja/deviceapi/BluetoothReader_OnDataChangeListenerImplementor"
	.zero	17

	/* #828 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554461
	/* java_name */
	.ascii	"mono/com/zebra/adc/decoder/BarCodeReader_OnZoomChangeListenerImplementor"
	.zero	17

	/* #829 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33555083
	/* java_name */
	.ascii	"mono/java/lang/RunnableImplementor"
	.zero	55

	/* #830 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554557
	/* java_name */
	.ascii	"org/json/JSONObject"
	.zero	70

	/* #831 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554558
	/* java_name */
	.ascii	"org/json/JSONStringer"
	.zero	68

	/* #832 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554553
	/* java_name */
	.ascii	"xamarin/android/net/OldAndroidSSLSocketFactory"
	.zero	43

	.size	map_java, 80801
/* Java to managed map: END */

