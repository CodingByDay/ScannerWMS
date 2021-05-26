	.arch	armv8-a
	.file	"typemaps.arm64-v8a.s"

/* map_module_count: START */
	.section	.rodata.map_module_count,"a",@progbits
	.type	map_module_count, @object
	.p2align	2
	.global	map_module_count
map_module_count:
	.size	map_module_count, 4
	.word	20
/* map_module_count: END */

/* java_type_count: START */
	.section	.rodata.java_type_count,"a",@progbits
	.type	java_type_count, @object
	.p2align	2
	.global	java_type_count
java_type_count:
	.size	java_type_count, 4
	.word	873
/* java_type_count: END */

/* java_name_width: START */
	.section	.rodata.java_name_width,"a",@progbits
	.type	java_name_width, @object
	.p2align	2
	.global	java_name_width
java_name_width:
	.size	java_name_width, 4
	.word	89
/* java_name_width: END */

	.include	"typemaps.shared.inc"
	.include	"typemaps.arm64-v8a-managed.inc"

/* Managed to Java map: START */
	.section	.data.rel.map_modules,"aw",@progbits
	.type	map_modules, @object
	.p2align	3
	.global	map_modules
map_modules:
	/* module_uuid: c080041a-e3e8-4da4-9a4b-dacc67237cfe */
	.byte	0x1a, 0x04, 0x80, 0xc0, 0xe8, 0xe3, 0xa4, 0x4d, 0x9a, 0x4b, 0xda, 0xcc, 0x67, 0x23, 0x7c, 0xfe
	/* entry_count */
	.word	97
	/* duplicate_count */
	.word	6
	/* map */
	.xword	module0_managed_to_java
	/* duplicate_map */
	.xword	module0_managed_to_java_duplicates
	/* assembly_name: Microsoft.AppCenter.Android.Bindings */
	.xword	.L.map_aname.0
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 5b459123-67cc-484d-8df8-7210de5e32a8 */
	.byte	0x23, 0x91, 0x45, 0x5b, 0xcc, 0x67, 0x4d, 0x48, 0x8d, 0xf8, 0x72, 0x10, 0xde, 0x5e, 0x32, 0xa8
	/* entry_count */
	.word	9
	/* duplicate_count */
	.word	3
	/* map */
	.xword	module1_managed_to_java
	/* duplicate_map */
	.xword	module1_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.Fragment */
	.xword	.L.map_aname.1
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 0d469737-7cab-4b5d-9e93-be53a4f30d70 */
	.byte	0x37, 0x97, 0x46, 0x0d, 0xab, 0x7c, 0x5d, 0x4b, 0x9e, 0x93, 0xbe, 0x53, 0xa4, 0xf3, 0x0d, 0x70
	/* entry_count */
	.word	3
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module2_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Xamarin.Android.Support.DrawerLayout */
	.xword	.L.map_aname.2
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: b8133439-8cc7-4079-a9a3-fd61f42c670b */
	.byte	0x39, 0x34, 0x13, 0xb8, 0xc7, 0x8c, 0x79, 0x40, 0xa9, 0xa3, 0xfd, 0x61, 0xf4, 0x2c, 0x67, 0x0b
	/* entry_count */
	.word	5
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module3_managed_to_java
	/* duplicate_map */
	.xword	module3_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.Loader */
	.xword	.L.map_aname.3
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: d2d48d48-c917-4ef4-ade9-c0b2be27f441 */
	.byte	0x48, 0x8d, 0xd4, 0xd2, 0x17, 0xc9, 0xf4, 0x4e, 0xad, 0xe9, 0xc0, 0xb2, 0xbe, 0x27, 0xf4, 0x41
	/* entry_count */
	.word	2
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module4_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Microsoft.AppCenter */
	.xword	.L.map_aname.4
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: ca6a0449-ebde-4ee2-ab3f-e244848d72bc */
	.byte	0x49, 0x04, 0x6a, 0xca, 0xde, 0xeb, 0xe2, 0x4e, 0xab, 0x3f, 0xe2, 0x44, 0x84, 0x8d, 0x72, 0xbc
	/* entry_count */
	.word	109
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module5_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: WMS */
	.xword	.L.map_aname.5
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: d3449557-6833-4fc3-bbb0-9c7561e96706 */
	.byte	0x57, 0x95, 0x44, 0xd3, 0x33, 0x68, 0xc3, 0x4f, 0xbb, 0xb0, 0x9c, 0x75, 0x61, 0xe9, 0x67, 0x06
	/* entry_count */
	.word	21
	/* duplicate_count */
	.word	3
	/* map */
	.xword	module6_managed_to_java
	/* duplicate_map */
	.xword	module6_managed_to_java_duplicates
	/* assembly_name: Microsoft.AppCenter.Distribute.Android.Bindings */
	.xword	.L.map_aname.6
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: d0906070-920c-4ebd-a390-173ac972b67c */
	.byte	0x70, 0x60, 0x90, 0xd0, 0x0c, 0x92, 0xbd, 0x4e, 0xa3, 0x90, 0x17, 0x3a, 0xc9, 0x72, 0xb6, 0x7c
	/* entry_count */
	.word	2
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module7_managed_to_java
	/* duplicate_map */
	.xword	module7_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Arch.Lifecycle.LiveData.Core */
	.xword	.L.map_aname.7
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 85fb4275-7576-46f0-9cf0-a8af35b9f4d8 */
	.byte	0x75, 0x42, 0xfb, 0x85, 0x76, 0x75, 0xf0, 0x46, 0x9c, 0xf0, 0xa8, 0xaf, 0x35, 0xb9, 0xf4, 0xd8
	/* entry_count */
	.word	21
	/* duplicate_count */
	.word	2
	/* map */
	.xword	module8_managed_to_java
	/* duplicate_map */
	.xword	module8_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.Compat */
	.xword	.L.map_aname.8
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 00a46e84-7f9e-4b3d-873f-39297ddbc0b2 */
	.byte	0x84, 0x6e, 0xa4, 0x00, 0x9e, 0x7f, 0x3d, 0x4b, 0x87, 0x3f, 0x39, 0x29, 0x7d, 0xdb, 0xc0, 0xb2
	/* entry_count */
	.word	18
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module9_managed_to_java
	/* duplicate_map */
	.xword	module9_managed_to_java_duplicates
	/* assembly_name: Microsoft.AppCenter.Analytics.Android.Bindings */
	.xword	.L.map_aname.9
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: b19a229d-bc59-47dd-93eb-5c88a4fe3047 */
	.byte	0x9d, 0x22, 0x9a, 0xb1, 0x59, 0xbc, 0xdd, 0x47, 0x93, 0xeb, 0x5c, 0x88, 0xa4, 0xfe, 0x30, 0x47
	/* entry_count */
	.word	30
	/* duplicate_count */
	.word	4
	/* map */
	.xword	module10_managed_to_java
	/* duplicate_map */
	.xword	module10_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.v7.AppCompat */
	.xword	.L.map_aname.10
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 16079b9d-b234-4886-87d6-b4d2b4cde63e */
	.byte	0x9d, 0x9b, 0x07, 0x16, 0x34, 0xb2, 0x86, 0x48, 0x87, 0xd6, 0xb4, 0xd2, 0xb4, 0xcd, 0xe6, 0x3e
	/* entry_count */
	.word	1
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module11_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Xamarin.Essentials */
	.xword	.L.map_aname.11
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: f6ace1b3-ca85-4b2e-bf6b-d6c96b92ca5d */
	.byte	0xb3, 0xe1, 0xac, 0xf6, 0x85, 0xca, 0x2e, 0x4b, 0xbf, 0x6b, 0xd6, 0xc9, 0x6b, 0x92, 0xca, 0x5d
	/* entry_count */
	.word	17
	/* duplicate_count */
	.word	2
	/* map */
	.xword	module12_managed_to_java
	/* duplicate_map */
	.xword	module12_managed_to_java_duplicates
	/* assembly_name: Microsoft.AppCenter.Crashes.Android.Bindings */
	.xword	.L.map_aname.12
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: eb1780be-e9dd-4dee-8a7a-2ff6de25919b */
	.byte	0xbe, 0x80, 0x17, 0xeb, 0xdd, 0xe9, 0xee, 0x4d, 0x8a, 0x7a, 0x2f, 0xf6, 0xde, 0x25, 0x91, 0x9b
	/* entry_count */
	.word	5
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module13_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: EDMTBinding */
	.xword	.L.map_aname.13
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 6ab406c2-7f04-4088-b058-2ed5df66c238 */
	.byte	0xc2, 0x06, 0xb4, 0x6a, 0x04, 0x7f, 0x88, 0x40, 0xb0, 0x58, 0x2e, 0xd5, 0xdf, 0x66, 0xc2, 0x38
	/* entry_count */
	.word	4
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module14_managed_to_java
	/* duplicate_map */
	.xword	module14_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Arch.Lifecycle.Common */
	.xword	.L.map_aname.14
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 83a9cbc3-fe28-48b4-8468-572beca4f69a */
	.byte	0xc3, 0xcb, 0xa9, 0x83, 0x28, 0xfe, 0xb4, 0x48, 0x84, 0x68, 0x57, 0x2b, 0xec, 0xa4, 0xf6, 0x9a
	/* entry_count */
	.word	207
	/* duplicate_count */
	.word	7
	/* map */
	.xword	module15_managed_to_java
	/* duplicate_map */
	.xword	module15_managed_to_java_duplicates
	/* assembly_name: DeviceAPI */
	.xword	.L.map_aname.15
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: edd9ebcd-4e65-4f04-9af6-56987a9c8986 */
	.byte	0xcd, 0xeb, 0xd9, 0xed, 0x65, 0x4e, 0x04, 0x4f, 0x9a, 0xf6, 0x56, 0x98, 0x7a, 0x9c, 0x89, 0x86
	/* entry_count */
	.word	1
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module16_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Microsoft.AppCenter.Crashes */
	.xword	.L.map_aname.16
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: be36facf-e235-47cc-a572-fdb5b8734b98 */
	.byte	0xcf, 0xfa, 0x36, 0xbe, 0x35, 0xe2, 0xcc, 0x47, 0xa5, 0x72, 0xfd, 0xb5, 0xb8, 0x73, 0x4b, 0x98
	/* entry_count */
	.word	1
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module17_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Microsoft.AppCenter.Distribute */
	.xword	.L.map_aname.17
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: e4048fd9-f99b-4e68-ab20-4fc1fb513337 */
	.byte	0xd9, 0x8f, 0x04, 0xe4, 0x9b, 0xf9, 0x68, 0x4e, 0xab, 0x20, 0x4f, 0xc1, 0xfb, 0x51, 0x33, 0x37
	/* entry_count */
	.word	2
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module18_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Xamarin.Android.Arch.Lifecycle.ViewModel */
	.xword	.L.map_aname.18
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 20762de1-11d4-4ea0-9e3a-6cf80f4651f0 */
	.byte	0xe1, 0x2d, 0x76, 0x20, 0xd4, 0x11, 0xa0, 0x4e, 0x9e, 0x3a, 0x6c, 0xf8, 0x0f, 0x46, 0x51, 0xf0
	/* entry_count */
	.word	318
	/* duplicate_count */
	.word	56
	/* map */
	.xword	module19_managed_to_java
	/* duplicate_map */
	.xword	module19_managed_to_java_duplicates
	/* assembly_name: Mono.Android */
	.xword	.L.map_aname.19
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	.size	map_modules, 1440
/* Managed to Java map: END */

/* Java to managed map: START */
	.section	.rodata.map_java,"a",@progbits
	.type	map_java, @object
	.p2align	2
	.global	map_java
map_java:
	/* #0 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554838
	/* java_name */
	.ascii	"android/animation/Animator"
	.zero	63

	/* #1 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554840
	/* java_name */
	.ascii	"android/animation/Animator$AnimatorListener"
	.zero	46

	/* #2 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554842
	/* java_name */
	.ascii	"android/animation/Animator$AnimatorPauseListener"
	.zero	41

	/* #3 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554844
	/* java_name */
	.ascii	"android/animation/AnimatorListenerAdapter"
	.zero	48

	/* #4 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554847
	/* java_name */
	.ascii	"android/animation/TimeInterpolator"
	.zero	55

	/* #5 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554849
	/* java_name */
	.ascii	"android/app/Activity"
	.zero	69

	/* #6 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554850
	/* java_name */
	.ascii	"android/app/AlertDialog"
	.zero	66

	/* #7 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554851
	/* java_name */
	.ascii	"android/app/AlertDialog$Builder"
	.zero	58

	/* #8 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554852
	/* java_name */
	.ascii	"android/app/Application"
	.zero	66

	/* #9 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554854
	/* java_name */
	.ascii	"android/app/Application$ActivityLifecycleCallbacks"
	.zero	39

	/* #10 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554855
	/* java_name */
	.ascii	"android/app/DatePickerDialog"
	.zero	61

	/* #11 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554857
	/* java_name */
	.ascii	"android/app/DatePickerDialog$OnDateSetListener"
	.zero	43

	/* #12 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554858
	/* java_name */
	.ascii	"android/app/Dialog"
	.zero	71

	/* #13 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554864
	/* java_name */
	.ascii	"android/app/DialogFragment"
	.zero	63

	/* #14 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554865
	/* java_name */
	.ascii	"android/app/Fragment"
	.zero	69

	/* #15 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554859
	/* java_name */
	.ascii	"android/app/FragmentManager"
	.zero	62

	/* #16 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554867
	/* java_name */
	.ascii	"android/app/PendingIntent"
	.zero	64

	/* #17 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554860
	/* java_name */
	.ascii	"android/app/ProgressDialog"
	.zero	63

	/* #18 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"android/arch/lifecycle/Lifecycle"
	.zero	57

	/* #19 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554436
	/* java_name */
	.ascii	"android/arch/lifecycle/Lifecycle$State"
	.zero	51

	/* #20 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"android/arch/lifecycle/LifecycleObserver"
	.zero	49

	/* #21 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"android/arch/lifecycle/LifecycleOwner"
	.zero	52

	/* #22 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"android/arch/lifecycle/LiveData"
	.zero	58

	/* #23 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554436
	/* java_name */
	.ascii	"android/arch/lifecycle/Observer"
	.zero	58

	/* #24 */
	/* module_index */
	.word	18
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"android/arch/lifecycle/ViewModelStore"
	.zero	52

	/* #25 */
	/* module_index */
	.word	18
	/* type_token_id */
	.word	33554436
	/* java_name */
	.ascii	"android/arch/lifecycle/ViewModelStoreOwner"
	.zero	47

	/* #26 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554835
	/* java_name */
	.ascii	"android/bluetooth/BluetoothDevice"
	.zero	56

	/* #27 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554836
	/* java_name */
	.ascii	"android/bluetooth/BluetoothGattCharacteristic"
	.zero	44

	/* #28 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554837
	/* java_name */
	.ascii	"android/bluetooth/BluetoothGattService"
	.zero	51

	/* #29 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554872
	/* java_name */
	.ascii	"android/content/BroadcastReceiver"
	.zero	56

	/* #30 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554879
	/* java_name */
	.ascii	"android/content/ComponentCallbacks"
	.zero	55

	/* #31 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554881
	/* java_name */
	.ascii	"android/content/ComponentCallbacks2"
	.zero	54

	/* #32 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554874
	/* java_name */
	.ascii	"android/content/ComponentName"
	.zero	60

	/* #33 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554869
	/* java_name */
	.ascii	"android/content/Context"
	.zero	66

	/* #34 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554876
	/* java_name */
	.ascii	"android/content/ContextWrapper"
	.zero	59

	/* #35 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554891
	/* java_name */
	.ascii	"android/content/DialogInterface"
	.zero	58

	/* #36 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554883
	/* java_name */
	.ascii	"android/content/DialogInterface$OnCancelListener"
	.zero	41

	/* #37 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554885
	/* java_name */
	.ascii	"android/content/DialogInterface$OnClickListener"
	.zero	42

	/* #38 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554889
	/* java_name */
	.ascii	"android/content/DialogInterface$OnDismissListener"
	.zero	40

	/* #39 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554870
	/* java_name */
	.ascii	"android/content/Intent"
	.zero	67

	/* #40 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554892
	/* java_name */
	.ascii	"android/content/IntentFilter"
	.zero	61

	/* #41 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554893
	/* java_name */
	.ascii	"android/content/IntentSender"
	.zero	61

	/* #42 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554899
	/* java_name */
	.ascii	"android/content/SharedPreferences"
	.zero	56

	/* #43 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554895
	/* java_name */
	.ascii	"android/content/SharedPreferences$Editor"
	.zero	49

	/* #44 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554897
	/* java_name */
	.ascii	"android/content/SharedPreferences$OnSharedPreferenceChangeListener"
	.zero	23

	/* #45 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554901
	/* java_name */
	.ascii	"android/content/pm/PackageInfo"
	.zero	59

	/* #46 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554903
	/* java_name */
	.ascii	"android/content/pm/PackageManager"
	.zero	56

	/* #47 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554907
	/* java_name */
	.ascii	"android/content/res/AssetManager"
	.zero	57

	/* #48 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554908
	/* java_name */
	.ascii	"android/content/res/ColorStateList"
	.zero	55

	/* #49 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554909
	/* java_name */
	.ascii	"android/content/res/Configuration"
	.zero	56

	/* #50 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554910
	/* java_name */
	.ascii	"android/content/res/Resources"
	.zero	60

	/* #51 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554911
	/* java_name */
	.ascii	"android/content/res/Resources$Theme"
	.zero	54

	/* #52 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554586
	/* java_name */
	.ascii	"android/database/DataSetObserver"
	.zero	57

	/* #53 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554815
	/* java_name */
	.ascii	"android/graphics/Bitmap"
	.zero	66

	/* #54 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554819
	/* java_name */
	.ascii	"android/graphics/BitmapFactory"
	.zero	59

	/* #55 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554820
	/* java_name */
	.ascii	"android/graphics/BitmapFactory$Options"
	.zero	51

	/* #56 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554816
	/* java_name */
	.ascii	"android/graphics/Canvas"
	.zero	66

	/* #57 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554821
	/* java_name */
	.ascii	"android/graphics/ColorFilter"
	.zero	61

	/* #58 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554823
	/* java_name */
	.ascii	"android/graphics/Matrix"
	.zero	66

	/* #59 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554824
	/* java_name */
	.ascii	"android/graphics/Paint"
	.zero	67

	/* #60 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554825
	/* java_name */
	.ascii	"android/graphics/Point"
	.zero	67

	/* #61 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554826
	/* java_name */
	.ascii	"android/graphics/PorterDuff"
	.zero	62

	/* #62 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554827
	/* java_name */
	.ascii	"android/graphics/PorterDuff$Mode"
	.zero	57

	/* #63 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554828
	/* java_name */
	.ascii	"android/graphics/Rect"
	.zero	68

	/* #64 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554829
	/* java_name */
	.ascii	"android/graphics/RectF"
	.zero	67

	/* #65 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554833
	/* java_name */
	.ascii	"android/graphics/drawable/BitmapDrawable"
	.zero	49

	/* #66 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554830
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable"
	.zero	55

	/* #67 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554832
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable$Callback"
	.zero	46

	/* #68 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554813
	/* java_name */
	.ascii	"android/hardware/usb/UsbDevice"
	.zero	59

	/* #69 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554811
	/* java_name */
	.ascii	"android/media/SoundPool"
	.zero	66

	/* #70 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554807
	/* java_name */
	.ascii	"android/net/ConnectivityManager"
	.zero	58

	/* #71 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554808
	/* java_name */
	.ascii	"android/net/NetworkInfo"
	.zero	66

	/* #72 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554809
	/* java_name */
	.ascii	"android/net/Uri"
	.zero	74

	/* #73 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/os/AsyncTask"
	.zero	69

	/* #74 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554795
	/* java_name */
	.ascii	"android/os/BaseBundle"
	.zero	68

	/* #75 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554796
	/* java_name */
	.ascii	"android/os/Build"
	.zero	73

	/* #76 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554797
	/* java_name */
	.ascii	"android/os/Build$VERSION"
	.zero	65

	/* #77 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554799
	/* java_name */
	.ascii	"android/os/Bundle"
	.zero	72

	/* #78 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554792
	/* java_name */
	.ascii	"android/os/Handler"
	.zero	71

	/* #79 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554804
	/* java_name */
	.ascii	"android/os/Looper"
	.zero	72

	/* #80 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554805
	/* java_name */
	.ascii	"android/os/Parcel"
	.zero	72

	/* #81 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554803
	/* java_name */
	.ascii	"android/os/Parcelable"
	.zero	68

	/* #82 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554801
	/* java_name */
	.ascii	"android/os/Parcelable$Creator"
	.zero	60

	/* #83 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554790
	/* java_name */
	.ascii	"android/preference/PreferenceManager"
	.zero	53

	/* #84 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554958
	/* java_name */
	.ascii	"android/runtime/JavaProxyThrowable"
	.zero	55

	/* #85 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"android/support/v13/view/DragAndDropPermissionsCompat"
	.zero	36

	/* #86 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554461
	/* java_name */
	.ascii	"android/support/v4/app/ActivityCompat"
	.zero	52

	/* #87 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554463
	/* java_name */
	.ascii	"android/support/v4/app/ActivityCompat$OnRequestPermissionsResultCallback"
	.zero	17

	/* #88 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554465
	/* java_name */
	.ascii	"android/support/v4/app/ActivityCompat$PermissionCompatDelegate"
	.zero	27

	/* #89 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554467
	/* java_name */
	.ascii	"android/support/v4/app/ActivityCompat$RequestPermissionsRequestCodeValidator"
	.zero	13

	/* #90 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554436
	/* java_name */
	.ascii	"android/support/v4/app/Fragment"
	.zero	58

	/* #91 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"android/support/v4/app/Fragment$SavedState"
	.zero	47

	/* #92 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"android/support/v4/app/FragmentActivity"
	.zero	50

	/* #93 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"android/support/v4/app/FragmentManager"
	.zero	51

	/* #94 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"android/support/v4/app/FragmentManager$BackStackEntry"
	.zero	36

	/* #95 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"android/support/v4/app/FragmentManager$FragmentLifecycleCallbacks"
	.zero	24

	/* #96 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554444
	/* java_name */
	.ascii	"android/support/v4/app/FragmentManager$OnBackStackChangedListener"
	.zero	24

	/* #97 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554449
	/* java_name */
	.ascii	"android/support/v4/app/FragmentTransaction"
	.zero	47

	/* #98 */
	/* module_index */
	.word	3
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"android/support/v4/app/LoaderManager"
	.zero	53

	/* #99 */
	/* module_index */
	.word	3
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"android/support/v4/app/LoaderManager$LoaderCallbacks"
	.zero	37

	/* #100 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554468
	/* java_name */
	.ascii	"android/support/v4/app/SharedElementCallback"
	.zero	45

	/* #101 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554470
	/* java_name */
	.ascii	"android/support/v4/app/SharedElementCallback$OnSharedElementsReadyListener"
	.zero	15

	/* #102 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554472
	/* java_name */
	.ascii	"android/support/v4/app/TaskStackBuilder"
	.zero	50

	/* #103 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554474
	/* java_name */
	.ascii	"android/support/v4/app/TaskStackBuilder$SupportParentable"
	.zero	32

	/* #104 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554459
	/* java_name */
	.ascii	"android/support/v4/content/ContextCompat"
	.zero	49

	/* #105 */
	/* module_index */
	.word	3
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"android/support/v4/content/Loader"
	.zero	56

	/* #106 */
	/* module_index */
	.word	3
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"android/support/v4/content/Loader$OnLoadCanceledListener"
	.zero	33

	/* #107 */
	/* module_index */
	.word	3
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"android/support/v4/content/Loader$OnLoadCompleteListener"
	.zero	33

	/* #108 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554460
	/* java_name */
	.ascii	"android/support/v4/content/pm/PackageInfoCompat"
	.zero	42

	/* #109 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554456
	/* java_name */
	.ascii	"android/support/v4/internal/view/SupportMenu"
	.zero	45

	/* #110 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554458
	/* java_name */
	.ascii	"android/support/v4/internal/view/SupportMenuItem"
	.zero	41

	/* #111 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554436
	/* java_name */
	.ascii	"android/support/v4/view/ActionProvider"
	.zero	51

	/* #112 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"android/support/v4/view/ActionProvider$SubUiVisibilityListener"
	.zero	27

	/* #113 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"android/support/v4/view/ActionProvider$VisibilityListener"
	.zero	32

	/* #114 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554454
	/* java_name */
	.ascii	"android/support/v4/view/ViewPropertyAnimatorCompat"
	.zero	39

	/* #115 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554451
	/* java_name */
	.ascii	"android/support/v4/view/ViewPropertyAnimatorListener"
	.zero	37

	/* #116 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554453
	/* java_name */
	.ascii	"android/support/v4/view/ViewPropertyAnimatorUpdateListener"
	.zero	31

	/* #117 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"android/support/v4/widget/DrawerLayout"
	.zero	51

	/* #118 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"android/support/v4/widget/DrawerLayout$DrawerListener"
	.zero	36

	/* #119 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554436
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar"
	.zero	57

	/* #120 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$LayoutParams"
	.zero	44

	/* #121 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$OnMenuVisibilityListener"
	.zero	32

	/* #122 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554443
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$OnNavigationListener"
	.zero	36

	/* #123 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554444
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$Tab"
	.zero	53

	/* #124 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554447
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$TabListener"
	.zero	45

	/* #125 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554451
	/* java_name */
	.ascii	"android/support/v7/app/ActionBarDrawerToggle"
	.zero	45

	/* #126 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554453
	/* java_name */
	.ascii	"android/support/v7/app/ActionBarDrawerToggle$Delegate"
	.zero	36

	/* #127 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554455
	/* java_name */
	.ascii	"android/support/v7/app/ActionBarDrawerToggle$DelegateProvider"
	.zero	28

	/* #128 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554456
	/* java_name */
	.ascii	"android/support/v7/app/AppCompatActivity"
	.zero	49

	/* #129 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554460
	/* java_name */
	.ascii	"android/support/v7/app/AppCompatCallback"
	.zero	49

	/* #130 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554457
	/* java_name */
	.ascii	"android/support/v7/app/AppCompatDelegate"
	.zero	49

	/* #131 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"android/support/v7/graphics/drawable/DrawerArrowDrawable"
	.zero	33

	/* #132 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554474
	/* java_name */
	.ascii	"android/support/v7/view/ActionMode"
	.zero	55

	/* #133 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554476
	/* java_name */
	.ascii	"android/support/v7/view/ActionMode$Callback"
	.zero	46

	/* #134 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554478
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuBuilder"
	.zero	49

	/* #135 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554480
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuBuilder$Callback"
	.zero	40

	/* #136 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554487
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuItemImpl"
	.zero	48

	/* #137 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554484
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuPresenter"
	.zero	47

	/* #138 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554482
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuPresenter$Callback"
	.zero	38

	/* #139 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554486
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuView"
	.zero	52

	/* #140 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554488
	/* java_name */
	.ascii	"android/support/v7/view/menu/SubMenuBuilder"
	.zero	46

	/* #141 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554471
	/* java_name */
	.ascii	"android/support/v7/widget/DecorToolbar"
	.zero	51

	/* #142 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554472
	/* java_name */
	.ascii	"android/support/v7/widget/ScrollingTabContainerView"
	.zero	38

	/* #143 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554473
	/* java_name */
	.ascii	"android/support/v7/widget/ScrollingTabContainerView$VisibilityAnimListener"
	.zero	15

	/* #144 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554461
	/* java_name */
	.ascii	"android/support/v7/widget/Toolbar"
	.zero	56

	/* #145 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554465
	/* java_name */
	.ascii	"android/support/v7/widget/Toolbar$OnMenuItemClickListener"
	.zero	32

	/* #146 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554462
	/* java_name */
	.ascii	"android/support/v7/widget/Toolbar_NavigationOnClickEventDispatcher"
	.zero	23

	/* #147 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554772
	/* java_name */
	.ascii	"android/text/Editable"
	.zero	68

	/* #148 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554775
	/* java_name */
	.ascii	"android/text/GetChars"
	.zero	68

	/* #149 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554778
	/* java_name */
	.ascii	"android/text/InputFilter"
	.zero	65

	/* #150 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554780
	/* java_name */
	.ascii	"android/text/NoCopySpan"
	.zero	66

	/* #151 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554782
	/* java_name */
	.ascii	"android/text/Spannable"
	.zero	67

	/* #152 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554785
	/* java_name */
	.ascii	"android/text/Spanned"
	.zero	69

	/* #153 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554788
	/* java_name */
	.ascii	"android/text/TextWatcher"
	.zero	65

	/* #154 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554769
	/* java_name */
	.ascii	"android/util/AttributeSet"
	.zero	64

	/* #155 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554767
	/* java_name */
	.ascii	"android/util/DisplayMetrics"
	.zero	62

	/* #156 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554766
	/* java_name */
	.ascii	"android/util/Log"
	.zero	73

	/* #157 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554770
	/* java_name */
	.ascii	"android/util/SparseArray"
	.zero	65

	/* #158 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554693
	/* java_name */
	.ascii	"android/view/ActionMode"
	.zero	66

	/* #159 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554695
	/* java_name */
	.ascii	"android/view/ActionMode$Callback"
	.zero	57

	/* #160 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554698
	/* java_name */
	.ascii	"android/view/ActionProvider"
	.zero	62

	/* #161 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554705
	/* java_name */
	.ascii	"android/view/CollapsibleActionView"
	.zero	55

	/* #162 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554709
	/* java_name */
	.ascii	"android/view/ContextMenu"
	.zero	65

	/* #163 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554707
	/* java_name */
	.ascii	"android/view/ContextMenu$ContextMenuInfo"
	.zero	49

	/* #164 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554700
	/* java_name */
	.ascii	"android/view/ContextThemeWrapper"
	.zero	57

	/* #165 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554701
	/* java_name */
	.ascii	"android/view/Display"
	.zero	69

	/* #166 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554702
	/* java_name */
	.ascii	"android/view/DragEvent"
	.zero	67

	/* #167 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554718
	/* java_name */
	.ascii	"android/view/InputEvent"
	.zero	66

	/* #168 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554674
	/* java_name */
	.ascii	"android/view/KeyEvent"
	.zero	68

	/* #169 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554676
	/* java_name */
	.ascii	"android/view/KeyEvent$Callback"
	.zero	59

	/* #170 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554677
	/* java_name */
	.ascii	"android/view/LayoutInflater"
	.zero	62

	/* #171 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554679
	/* java_name */
	.ascii	"android/view/LayoutInflater$Factory"
	.zero	54

	/* #172 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554681
	/* java_name */
	.ascii	"android/view/LayoutInflater$Factory2"
	.zero	53

	/* #173 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554711
	/* java_name */
	.ascii	"android/view/Menu"
	.zero	72

	/* #174 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554738
	/* java_name */
	.ascii	"android/view/MenuInflater"
	.zero	64

	/* #175 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554717
	/* java_name */
	.ascii	"android/view/MenuItem"
	.zero	68

	/* #176 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554713
	/* java_name */
	.ascii	"android/view/MenuItem$OnActionExpandListener"
	.zero	45

	/* #177 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554715
	/* java_name */
	.ascii	"android/view/MenuItem$OnMenuItemClickListener"
	.zero	44

	/* #178 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554682
	/* java_name */
	.ascii	"android/view/MotionEvent"
	.zero	65

	/* #179 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554741
	/* java_name */
	.ascii	"android/view/SearchEvent"
	.zero	65

	/* #180 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554721
	/* java_name */
	.ascii	"android/view/SubMenu"
	.zero	69

	/* #181 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554744
	/* java_name */
	.ascii	"android/view/Surface"
	.zero	69

	/* #182 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554725
	/* java_name */
	.ascii	"android/view/SurfaceHolder"
	.zero	63

	/* #183 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554723
	/* java_name */
	.ascii	"android/view/SurfaceHolder$Callback"
	.zero	54

	/* #184 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554652
	/* java_name */
	.ascii	"android/view/View"
	.zero	72

	/* #185 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554654
	/* java_name */
	.ascii	"android/view/View$OnClickListener"
	.zero	56

	/* #186 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554657
	/* java_name */
	.ascii	"android/view/View$OnCreateContextMenuListener"
	.zero	44

	/* #187 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554659
	/* java_name */
	.ascii	"android/view/View$OnFocusChangeListener"
	.zero	50

	/* #188 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554663
	/* java_name */
	.ascii	"android/view/View$OnKeyListener"
	.zero	58

	/* #189 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554667
	/* java_name */
	.ascii	"android/view/View$OnTouchListener"
	.zero	56

	/* #190 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554748
	/* java_name */
	.ascii	"android/view/ViewGroup"
	.zero	67

	/* #191 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554749
	/* java_name */
	.ascii	"android/view/ViewGroup$LayoutParams"
	.zero	54

	/* #192 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554750
	/* java_name */
	.ascii	"android/view/ViewGroup$MarginLayoutParams"
	.zero	48

	/* #193 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554727
	/* java_name */
	.ascii	"android/view/ViewManager"
	.zero	65

	/* #194 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554729
	/* java_name */
	.ascii	"android/view/ViewParent"
	.zero	66

	/* #195 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554752
	/* java_name */
	.ascii	"android/view/ViewPropertyAnimator"
	.zero	56

	/* #196 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554683
	/* java_name */
	.ascii	"android/view/ViewTreeObserver"
	.zero	60

	/* #197 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554685
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnGlobalLayoutListener"
	.zero	37

	/* #198 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554687
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnPreDrawListener"
	.zero	42

	/* #199 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554689
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnTouchModeChangeListener"
	.zero	34

	/* #200 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554690
	/* java_name */
	.ascii	"android/view/Window"
	.zero	70

	/* #201 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554692
	/* java_name */
	.ascii	"android/view/Window$Callback"
	.zero	61

	/* #202 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554732
	/* java_name */
	.ascii	"android/view/WindowManager"
	.zero	63

	/* #203 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554730
	/* java_name */
	.ascii	"android/view/WindowManager$LayoutParams"
	.zero	50

	/* #204 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554759
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityEvent"
	.zero	44

	/* #205 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554765
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityEventSource"
	.zero	38

	/* #206 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554760
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityRecord"
	.zero	43

	/* #207 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554755
	/* java_name */
	.ascii	"android/view/animation/Animation"
	.zero	57

	/* #208 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554758
	/* java_name */
	.ascii	"android/view/animation/Interpolator"
	.zero	54

	/* #209 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554588
	/* java_name */
	.ascii	"android/widget/AbsListView"
	.zero	63

	/* #210 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554616
	/* java_name */
	.ascii	"android/widget/AbsSpinner"
	.zero	64

	/* #211 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554631
	/* java_name */
	.ascii	"android/widget/Adapter"
	.zero	67

	/* #212 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554590
	/* java_name */
	.ascii	"android/widget/AdapterView"
	.zero	63

	/* #213 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554592
	/* java_name */
	.ascii	"android/widget/AdapterView$OnItemClickListener"
	.zero	43

	/* #214 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554596
	/* java_name */
	.ascii	"android/widget/AdapterView$OnItemLongClickListener"
	.zero	39

	/* #215 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554600
	/* java_name */
	.ascii	"android/widget/AdapterView$OnItemSelectedListener"
	.zero	40

	/* #216 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/widget/ArrayAdapter"
	.zero	62

	/* #217 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554620
	/* java_name */
	.ascii	"android/widget/BaseAdapter"
	.zero	63

	/* #218 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554622
	/* java_name */
	.ascii	"android/widget/Button"
	.zero	68

	/* #219 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554612
	/* java_name */
	.ascii	"android/widget/DatePicker"
	.zero	64

	/* #220 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554614
	/* java_name */
	.ascii	"android/widget/DatePicker$OnDateChangedListener"
	.zero	42

	/* #221 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554623
	/* java_name */
	.ascii	"android/widget/EditText"
	.zero	66

	/* #222 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554624
	/* java_name */
	.ascii	"android/widget/Filter"
	.zero	68

	/* #223 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554626
	/* java_name */
	.ascii	"android/widget/Filter$FilterListener"
	.zero	53

	/* #224 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554633
	/* java_name */
	.ascii	"android/widget/Filterable"
	.zero	64

	/* #225 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554628
	/* java_name */
	.ascii	"android/widget/FrameLayout"
	.zero	63

	/* #226 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554629
	/* java_name */
	.ascii	"android/widget/HorizontalScrollView"
	.zero	54

	/* #227 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554636
	/* java_name */
	.ascii	"android/widget/ImageView"
	.zero	65

	/* #228 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554641
	/* java_name */
	.ascii	"android/widget/LinearLayout"
	.zero	62

	/* #229 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554635
	/* java_name */
	.ascii	"android/widget/ListAdapter"
	.zero	63

	/* #230 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554642
	/* java_name */
	.ascii	"android/widget/ListView"
	.zero	66

	/* #231 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554643
	/* java_name */
	.ascii	"android/widget/ProgressBar"
	.zero	63

	/* #232 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554644
	/* java_name */
	.ascii	"android/widget/SearchView"
	.zero	64

	/* #233 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554646
	/* java_name */
	.ascii	"android/widget/SearchView$OnCloseListener"
	.zero	48

	/* #234 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554648
	/* java_name */
	.ascii	"android/widget/SearchView$OnQueryTextListener"
	.zero	44

	/* #235 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554649
	/* java_name */
	.ascii	"android/widget/Spinner"
	.zero	67

	/* #236 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554638
	/* java_name */
	.ascii	"android/widget/SpinnerAdapter"
	.zero	60

	/* #237 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554615
	/* java_name */
	.ascii	"android/widget/TextView"
	.zero	66

	/* #238 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554640
	/* java_name */
	.ascii	"android/widget/ThemedSpinnerAdapter"
	.zero	54

	/* #239 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554650
	/* java_name */
	.ascii	"android/widget/Toast"
	.zero	69

	/* #240 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554723
	/* java_name */
	.ascii	"com/barcode/BarcodeUtility"
	.zero	63

	/* #241 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554724
	/* java_name */
	.ascii	"com/barcode/BarcodeUtility$ModuleType"
	.zero	52

	/* #242 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554717
	/* java_name */
	.ascii	"com/custom/Barcode2DSoftHuace"
	.zero	60

	/* #243 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554718
	/* java_name */
	.ascii	"com/custom/Barcode2DSoftHuace$Barcode2DScanCallback"
	.zero	38

	/* #244 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554719
	/* java_name */
	.ascii	"com/custom/Barcode2DSoftHuace$Barcode2DScanCallback2"
	.zero	37

	/* #245 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554721
	/* java_name */
	.ascii	"com/custom/BarcodeScanCallback"
	.zero	59

	/* #246 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554722
	/* java_name */
	.ascii	"com/custom/RFIDWithUHFUARTUAE"
	.zero	60

	/* #247 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554678
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeOptions"
	.zero	60

	/* #248 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554692
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeResult"
	.zero	61

	/* #249 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554695
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeWindowing"
	.zero	58

	/* #250 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554696
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeWindowing$DecodeWindow"
	.zero	45

	/* #251 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554697
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeWindowing$DecodeWindowLimits"
	.zero	39

	/* #252 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554698
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeWindowing$DecodeWindowMode"
	.zero	41

	/* #253 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554699
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeWindowing$DecodeWindowShowWindow"
	.zero	35

	/* #254 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554679
	/* java_name */
	.ascii	"com/hsm/barcode/Decoder"
	.zero	66

	/* #255 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554684
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues"
	.zero	54

	/* #256 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554685
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$EngineID"
	.zero	45

	/* #257 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554686
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$EngineType"
	.zero	43

	/* #258 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554687
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$LightsMode"
	.zero	43

	/* #259 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554688
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$OCRMode"
	.zero	46

	/* #260 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554689
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$OCRTemplate"
	.zero	42

	/* #261 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554690
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$SymbologyFlags"
	.zero	39

	/* #262 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554691
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$SymbologyID"
	.zero	42

	/* #263 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554693
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderException"
	.zero	57

	/* #264 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554694
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderException$ResultID"
	.zero	48

	/* #265 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554708
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderListener"
	.zero	58

	/* #266 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554700
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues"
	.zero	59

	/* #267 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554701
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues$ExposureMethod"
	.zero	44

	/* #268 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554702
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues$ExposureMode"
	.zero	46

	/* #269 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554703
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues$ExposureSettings"
	.zero	42

	/* #270 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554704
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues$ExposureSettingsMinMax"
	.zero	36

	/* #271 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554705
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues$SpecularExclusion"
	.zero	41

	/* #272 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554706
	/* java_name */
	.ascii	"com/hsm/barcode/HalInterface"
	.zero	61

	/* #273 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554714
	/* java_name */
	.ascii	"com/hsm/barcode/IQImagingProperties"
	.zero	54

	/* #274 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554715
	/* java_name */
	.ascii	"com/hsm/barcode/IQImagingProperties$IQImageFormat"
	.zero	40

	/* #275 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554712
	/* java_name */
	.ascii	"com/hsm/barcode/ImageAttributes"
	.zero	58

	/* #276 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554713
	/* java_name */
	.ascii	"com/hsm/barcode/ImagerProperties"
	.zero	57

	/* #277 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554716
	/* java_name */
	.ascii	"com/hsm/barcode/SymbologyConfig"
	.zero	58

	/* #278 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554672
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/AEData"
	.zero	53

	/* #279 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554673
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/DetailData"
	.zero	49

	/* #280 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554674
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/Result"
	.zero	53

	/* #281 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554675
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/SaveMode"
	.zero	51

	/* #282 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554676
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/SymbologyData"
	.zero	46

	/* #283 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554677
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/SymbologySettingItem"
	.zero	39

	/* #284 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"com/microsoft/appcenter/AbstractAppCenterService"
	.zero	41

	/* #285 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"com/microsoft/appcenter/AppCenter"
	.zero	56

	/* #286 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554445
	/* java_name */
	.ascii	"com/microsoft/appcenter/AppCenterHandler"
	.zero	49

	/* #287 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554447
	/* java_name */
	.ascii	"com/microsoft/appcenter/AppCenterService"
	.zero	49

	/* #288 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"com/microsoft/appcenter/BuildConfig"
	.zero	54

	/* #289 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"com/microsoft/appcenter/CancellationException"
	.zero	44

	/* #290 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"com/microsoft/appcenter/Constants"
	.zero	56

	/* #291 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"com/microsoft/appcenter/CustomProperties"
	.zero	49

	/* #292 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"com/microsoft/appcenter/DependencyConfiguration"
	.zero	42

	/* #293 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554443
	/* java_name */
	.ascii	"com/microsoft/appcenter/Flags"
	.zero	60

	/* #294 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554436
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/Analytics"
	.zero	46

	/* #295 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/AnalyticsTransmissionTarget"
	.zero	28

	/* #296 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/AuthenticationProvider"
	.zero	33

	/* #297 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/AuthenticationProvider$AuthenticationCallback"
	.zero	10

	/* #298 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/AuthenticationProvider$TokenProvider"
	.zero	19

	/* #299 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/AuthenticationProvider$Type"
	.zero	28

	/* #300 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554443
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/BuildConfig"
	.zero	44

	/* #301 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554444
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/EventProperties"
	.zero	40

	/* #302 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554445
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/PropertyConfigurator"
	.zero	35

	/* #303 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554454
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/channel/AnalyticsListener"
	.zero	30

	/* #304 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554452
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/channel/AnalyticsValidator"
	.zero	29

	/* #305 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554459
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/channel/SessionTracker"
	.zero	33

	/* #306 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554446
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/ingestion/models/EventLog"
	.zero	30

	/* #307 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554447
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/ingestion/models/LogWithNameAndProperties"
	.zero	14

	/* #308 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554449
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/ingestion/models/PageLog"
	.zero	31

	/* #309 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554450
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/ingestion/models/StartSessionLog"
	.zero	23

	/* #310 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554451
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/ingestion/models/one/CommonSchemaEventLog"
	.zero	14

	/* #311 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554553
	/* java_name */
	.ascii	"com/microsoft/appcenter/channel/AbstractChannelListener"
	.zero	34

	/* #312 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554573
	/* java_name */
	.ascii	"com/microsoft/appcenter/channel/Channel"
	.zero	50

	/* #313 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554555
	/* java_name */
	.ascii	"com/microsoft/appcenter/channel/Channel$GroupListener"
	.zero	36

	/* #314 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554561
	/* java_name */
	.ascii	"com/microsoft/appcenter/channel/Channel$Listener"
	.zero	41

	/* #315 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554574
	/* java_name */
	.ascii	"com/microsoft/appcenter/channel/OneCollectorChannelListener"
	.zero	30

	/* #316 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/AbstractCrashesListener"
	.zero	34

	/* #317 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/BuildConfig"
	.zero	46

	/* #318 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/Crashes"
	.zero	50

	/* #319 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/CrashesListener"
	.zero	42

	/* #320 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554448
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/WrapperSdkExceptionManager"
	.zero	31

	/* #321 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554453
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/AbstractErrorLog"
	.zero	24

	/* #322 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554455
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/ErrorAttachmentLog"
	.zero	22

	/* #323 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554456
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/Exception"
	.zero	31

	/* #324 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554457
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/HandledErrorLog"
	.zero	25

	/* #325 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554458
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/ManagedErrorLog"
	.zero	25

	/* #326 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554459
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/StackFrame"
	.zero	30

	/* #327 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554460
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/Thread"
	.zero	34

	/* #328 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554450
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/model/ErrorReport"
	.zero	40

	/* #329 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554452
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/model/NativeException"
	.zero	36

	/* #330 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554451
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/model/TestCrashException"
	.zero	33

	/* #331 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554449
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/utils/ErrorLogHelper"
	.zero	37

	/* #332 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/BuildConfig"
	.zero	43

	/* #333 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/DeepLinkActivity"
	.zero	38

	/* #334 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/Distribute"
	.zero	44

	/* #335 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/DistributeConstants"
	.zero	35

	/* #336 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/DistributeListener"
	.zero	36

	/* #337 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/DownloadManagerReceiver"
	.zero	31

	/* #338 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554450
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/InstallerUtils"
	.zero	40

	/* #339 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554451
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/PermissionUtils"
	.zero	39

	/* #340 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554436
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/ReleaseDetails"
	.zero	40

	/* #341 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554446
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/UpdateTrack"
	.zero	43

	/* #342 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554467
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/channel/DistributeInfoTracker"
	.zero	25

	/* #343 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554454
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/download/AbstractReleaseDownloader"
	.zero	20

	/* #344 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554464
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/download/ReleaseDownloader"
	.zero	28

	/* #345 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554457
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/download/ReleaseDownloader$Listener"
	.zero	19

	/* #346 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554465
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/download/ReleaseDownloaderFactory"
	.zero	21

	/* #347 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554466
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/download/manager/DownloadManagerReleaseDownloader"
	.zero	5

	/* #348 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554453
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/ingestion/models/DistributionStartSessionLog"
	.zero	10

	/* #349 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554548
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/HttpClient"
	.zero	50

	/* #350 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554546
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/HttpClient$CallTemplate"
	.zero	37

	/* #351 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554543
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/HttpException"
	.zero	47

	/* #352 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554544
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/HttpResponse"
	.zero	48

	/* #353 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554550
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/ServiceCall"
	.zero	49

	/* #354 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554552
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/ServiceCallback"
	.zero	45

	/* #355 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554489
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/AppCenterIngestion"
	.zero	37

	/* #356 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554491
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/Ingestion"
	.zero	46

	/* #357 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554492
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/OneCollectorIngestion"
	.zero	34

	/* #358 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554493
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/AbstractLog"
	.zero	37

	/* #359 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554495
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/CommonProperties"
	.zero	32

	/* #360 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554496
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/CustomPropertiesLog"
	.zero	29

	/* #361 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554497
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/Device"
	.zero	42

	/* #362 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554499
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/Log"
	.zero	45

	/* #363 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554502
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/LogContainer"
	.zero	36

	/* #364 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554503
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/LogWithProperties"
	.zero	31

	/* #365 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554501
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/Model"
	.zero	43

	/* #366 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554505
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/StartServiceLog"
	.zero	33

	/* #367 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554506
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/WrapperSdk"
	.zero	38

	/* #368 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554530
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/AbstractLogFactory"
	.zero	25

	/* #369 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554532
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/CustomPropertiesLogFactory"
	.zero	17

	/* #370 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554533
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/DefaultLogSerializer"
	.zero	23

	/* #371 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554540
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/JSONDateUtils"
	.zero	30

	/* #372 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554541
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/JSONUtils"
	.zero	34

	/* #373 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554535
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/LogFactory"
	.zero	33

	/* #374 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554537
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/LogSerializer"
	.zero	30

	/* #375 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554539
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/ModelFactory"
	.zero	31

	/* #376 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554542
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/StartServiceLogFactory"
	.zero	21

	/* #377 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554515
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/AppExtension"
	.zero	32

	/* #378 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554516
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/CommonSchemaDataUtils"
	.zero	23

	/* #379 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554517
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/CommonSchemaLog"
	.zero	29

	/* #380 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554519
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/Data"
	.zero	40

	/* #381 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554520
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/DeviceExtension"
	.zero	29

	/* #382 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554521
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/Extensions"
	.zero	34

	/* #383 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554522
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/LocExtension"
	.zero	32

	/* #384 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554523
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/MetadataExtension"
	.zero	27

	/* #385 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554524
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/NetExtension"
	.zero	32

	/* #386 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554525
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/OsExtension"
	.zero	33

	/* #387 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554526
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/PartAUtils"
	.zero	34

	/* #388 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554527
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/ProtocolExtension"
	.zero	27

	/* #389 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554528
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/SdkExtension"
	.zero	32

	/* #390 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554529
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/UserExtension"
	.zero	31

	/* #391 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554507
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/BooleanTypedProperty"
	.zero	17

	/* #392 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554508
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/DateTimeTypedProperty"
	.zero	16

	/* #393 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554509
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/DoubleTypedProperty"
	.zero	18

	/* #394 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554510
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/LongTypedProperty"
	.zero	20

	/* #395 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554511
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/StringTypedProperty"
	.zero	18

	/* #396 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554512
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/TypedProperty"
	.zero	24

	/* #397 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554514
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/TypedPropertyUtils"
	.zero	19

	/* #398 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554448
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/AppCenterLog"
	.zero	47

	/* #399 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554449
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/AppNameHelper"
	.zero	46

	/* #400 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554450
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/ApplicationLifecycleListener"
	.zero	31

	/* #401 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554452
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/ApplicationLifecycleListener$ApplicationLifecycleCallbacks"
	.zero	1

	/* #402 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554453
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/AsyncTaskUtils"
	.zero	45

	/* #403 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554454
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/DeviceInfoHelper"
	.zero	43

	/* #404 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554455
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/DeviceInfoHelper$DeviceInfoException"
	.zero	23

	/* #405 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554456
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/HandlerUtils"
	.zero	47

	/* #406 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554457
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/HashUtils"
	.zero	50

	/* #407 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554458
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/IdHelper"
	.zero	51

	/* #408 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554459
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/InstrumentationRegistryHelper"
	.zero	30

	/* #409 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554460
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/NetworkStateHelper"
	.zero	41

	/* #410 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554462
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/NetworkStateHelper$Listener"
	.zero	32

	/* #411 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554465
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/PrefStorageConstants"
	.zero	39

	/* #412 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554466
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/ShutdownHelper"
	.zero	45

	/* #413 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554467
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/TicketCache"
	.zero	48

	/* #414 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554486
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/async/AppCenterConsumer"
	.zero	36

	/* #415 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554488
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/async/AppCenterFuture"
	.zero	38

	/* #416 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554484
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/async/DefaultAppCenterFuture"
	.zero	31

	/* #417 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554477
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/context/SessionContext"
	.zero	37

	/* #418 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554478
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/context/SessionContext$SessionInfo"
	.zero	25

	/* #419 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554479
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/context/UserIdContext"
	.zero	38

	/* #420 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554481
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/context/UserIdContext$Listener"
	.zero	29

	/* #421 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554468
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils"
	.zero	41

	/* #422 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554469
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils$CryptoHandlerEntry"
	.zero	22

	/* #423 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554470
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils$DecryptedData"
	.zero	27

	/* #424 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554472
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils$ICipher"
	.zero	33

	/* #425 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554474
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils$ICryptoFactory"
	.zero	26

	/* #426 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554476
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils$IKeyGenerator"
	.zero	27

	/* #427 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554488
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation"
	.zero	57

	/* #428 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554490
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$BDLocationListener"
	.zero	38

	/* #429 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554494
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$BDProviderEnum"
	.zero	42

	/* #430 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554495
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$BDStartModeEnum"
	.zero	41

	/* #431 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554497
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$BDStatusListener"
	.zero	40

	/* #432 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554504
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$ReadThread"
	.zero	46

	/* #433 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554506
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$TestResultRawData"
	.zero	39

	/* #434 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554486
	/* java_name */
	.ascii	"com/rscja/deviceapi/Barcode1D"
	.zero	60

	/* #435 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554487
	/* java_name */
	.ascii	"com/rscja/deviceapi/Barcode2D"
	.zero	60

	/* #436 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554520
	/* java_name */
	.ascii	"com/rscja/deviceapi/BluetoothReader"
	.zero	54

	/* #437 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554522
	/* java_name */
	.ascii	"com/rscja/deviceapi/BluetoothReader$DataCallBack"
	.zero	41

	/* #438 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554524
	/* java_name */
	.ascii	"com/rscja/deviceapi/BluetoothReader$OnDataChangeListener"
	.zero	33

	/* #439 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554529
	/* java_name */
	.ascii	"com/rscja/deviceapi/CardWithBYL"
	.zero	58

	/* #440 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554530
	/* java_name */
	.ascii	"com/rscja/deviceapi/Device"
	.zero	63

	/* #441 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554532
	/* java_name */
	.ascii	"com/rscja/deviceapi/DeviceAPI"
	.zero	60

	/* #442 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554533
	/* java_name */
	.ascii	"com/rscja/deviceapi/DeviceConfiguration"
	.zero	50

	/* #443 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554534
	/* java_name */
	.ascii	"com/rscja/deviceapi/DeviceConfiguration$DeviceInfo"
	.zero	39

	/* #444 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554535
	/* java_name */
	.ascii	"com/rscja/deviceapi/Fingerprint"
	.zero	58

	/* #445 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554536
	/* java_name */
	.ascii	"com/rscja/deviceapi/Fingerprint$BufferEnum"
	.zero	47

	/* #446 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554537
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS"
	.zero	50

	/* #447 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554538
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$DataFormat"
	.zero	39

	/* #448 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554540
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$EnrollCallBack"
	.zero	35

	/* #449 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554541
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$FingerprintInfo"
	.zero	34

	/* #450 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554543
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$GRABCallBack"
	.zero	37

	/* #451 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554545
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$IdentificationCallBack"
	.zero	27

	/* #452 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554547
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$PtCaptureCallBack"
	.zero	32

	/* #453 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554549
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$TemplateVerifyCallBack"
	.zero	27

	/* #454 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554550
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$ThreadEnroll"
	.zero	37

	/* #455 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554551
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$ThreadGRAB"
	.zero	39

	/* #456 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554552
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$ThreadIdentification"
	.zero	29

	/* #457 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554553
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$ThreadPtCapture"
	.zero	34

	/* #458 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554554
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$ThreadTemplateVerify"
	.zero	29

	/* #459 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554555
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho"
	.zero	48

	/* #460 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554557
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$EnrollCallBack"
	.zero	33

	/* #461 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554559
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$IdentificationCallBack"
	.zero	25

	/* #462 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554560
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$MorphoMessage"
	.zero	34

	/* #463 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554562
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$PtCaptureCallBack"
	.zero	30

	/* #464 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554564
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$TemplateVerifyCallBack"
	.zero	25

	/* #465 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554565
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$ThreadEnroll"
	.zero	35

	/* #466 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554566
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$ThreadIdentification"
	.zero	27

	/* #467 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554567
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$ThreadPtCapture"
	.zero	32

	/* #468 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554568
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$ThreadPtCapturePKComp"
	.zero	26

	/* #469 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554569
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$ThreadTemplateVerify"
	.zero	27

	/* #470 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554570
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$TimeOutThread"
	.zero	34

	/* #471 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554571
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithZAZ"
	.zero	51

	/* #472 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554572
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithZAZ$BufferEnum"
	.zero	40

	/* #473 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554573
	/* java_name */
	.ascii	"com/rscja/deviceapi/Infrared"
	.zero	61

	/* #474 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554574
	/* java_name */
	.ascii	"com/rscja/deviceapi/LedLight"
	.zero	61

	/* #475 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554575
	/* java_name */
	.ascii	"com/rscja/deviceapi/Module"
	.zero	63

	/* #476 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554582
	/* java_name */
	.ascii	"com/rscja/deviceapi/PSAM"
	.zero	65

	/* #477 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554576
	/* java_name */
	.ascii	"com/rscja/deviceapi/Printer"
	.zero	62

	/* #478 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554577
	/* java_name */
	.ascii	"com/rscja/deviceapi/Printer$BarcodeType"
	.zero	50

	/* #479 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554578
	/* java_name */
	.ascii	"com/rscja/deviceapi/Printer$MeesageThread"
	.zero	48

	/* #480 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554579
	/* java_name */
	.ascii	"com/rscja/deviceapi/Printer$PrinterStatus"
	.zero	48

	/* #481 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554581
	/* java_name */
	.ascii	"com/rscja/deviceapi/Printer$PrinterStatusCallBack"
	.zero	40

	/* #482 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554583
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDBase"
	.zero	61

	/* #483 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554584
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A"
	.zero	52

	/* #484 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554585
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A$DESFireEncryptionTypekEnum"
	.zero	25

	/* #485 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554586
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A$DESFireFileTypekEnum"
	.zero	31

	/* #486 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554587
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A$KeyType"
	.zero	44

	/* #487 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554588
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A$TagType"
	.zero	44

	/* #488 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554589
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A4CPU"
	.zero	48

	/* #489 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554590
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443B"
	.zero	52

	/* #490 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554591
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO15693"
	.zero	53

	/* #491 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554592
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO15693$TagType"
	.zero	45

	/* #492 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554593
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithLF"
	.zero	59

	/* #493 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554594
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF"
	.zero	58

	/* #494 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554595
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF$BankEnum"
	.zero	49

	/* #495 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554596
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF$LockModeEnum"
	.zero	45

	/* #496 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554597
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF$SingelModeEnum"
	.zero	43

	/* #497 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554598
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF$SingleModeEnum"
	.zero	43

	/* #498 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554599
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF706"
	.zero	55

	/* #499 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554600
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFA8"
	.zero	56

	/* #500 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554601
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFA8$NotifyThread"
	.zero	43

	/* #501 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554602
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBLE"
	.zero	55

	/* #502 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554604
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth"
	.zero	49

	/* #503 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554606
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$BTStatusCallback"
	.zero	32

	/* #504 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554607
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$BankEnum"
	.zero	40

	/* #505 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554608
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$DataReceiveBTData"
	.zero	31

	/* #506 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554610
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$KeyEventCallback"
	.zero	32

	/* #507 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554612
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$ScanBTCallback"
	.zero	34

	/* #508 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554613
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$StatusEnum"
	.zero	38

	/* #509 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554614
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFUART"
	.zero	54

	/* #510 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554616
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFUSB"
	.zero	55

	/* #511 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554618
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFUSB$UsbReceiver"
	.zero	43

	/* #512 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554621
	/* java_name */
	.ascii	"com/rscja/deviceapi/SPI"
	.zero	66

	/* #513 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554619
	/* java_name */
	.ascii	"com/rscja/deviceapi/ScanerLedLight"
	.zero	55

	/* #514 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554620
	/* java_name */
	.ascii	"com/rscja/deviceapi/ScanerLedLight$OffTask"
	.zero	47

	/* #515 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554622
	/* java_name */
	.ascii	"com/rscja/deviceapi/UHFCustomAPI"
	.zero	57

	/* #516 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554623
	/* java_name */
	.ascii	"com/rscja/deviceapi/UHFProtocolParse"
	.zero	53

	/* #517 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554624
	/* java_name */
	.ascii	"com/rscja/deviceapi/UHFProtocolParseUSB"
	.zero	50

	/* #518 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554625
	/* java_name */
	.ascii	"com/rscja/deviceapi/VersionInfo"
	.zero	58

	/* #519 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554665
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/AnimalEntity"
	.zero	50

	/* #520 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554666
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/BDLocation"
	.zero	52

	/* #521 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554667
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/DESFireFile"
	.zero	51

	/* #522 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554668
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/ISO15693Entity"
	.zero	48

	/* #523 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554669
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/SatelliteEntity"
	.zero	47

	/* #524 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554670
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/SimpleRFIDEntity"
	.zero	46

	/* #525 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554671
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/UHFTAGInfo"
	.zero	52

	/* #526 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554654
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/ConfigurationException"
	.zero	37

	/* #527 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554655
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/DeviceNotConnectException"
	.zero	34

	/* #528 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554656
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/FingerprintAlreadyEnrolledException"
	.zero	24

	/* #529 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554657
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/FingerprintInvalidIDException"
	.zero	30

	/* #530 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554660
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/PSAMException"
	.zero	46

	/* #531 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554658
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/PrinterBarcodeInvalidException"
	.zero	29

	/* #532 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554659
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/PrinterLowPager"
	.zero	44

	/* #533 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554661
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/RFIDArgumentException"
	.zero	38

	/* #534 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554662
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/RFIDNotFoundException"
	.zero	38

	/* #535 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554663
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/RFIDReadFailureException"
	.zero	35

	/* #536 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554664
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/RFIDVerificationException"
	.zero	34

	/* #537 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554635
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/ConnectionStatus"
	.zero	42

	/* #538 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554641
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/ConnectionStatusCallback"
	.zero	34

	/* #539 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554636
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/IBluetoothReader"
	.zero	42

	/* #540 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554646
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/IUHF"
	.zero	54

	/* #541 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554651
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/IUHFProtocolParse"
	.zero	41

	/* #542 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554653
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/IUhfReader"
	.zero	48

	/* #543 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554643
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/KeyEventCallback"
	.zero	42

	/* #544 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554645
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/ScanBTCallback"
	.zero	44

	/* #545 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554629
	/* java_name */
	.ascii	"com/rscja/deviceapi/service/BLEService"
	.zero	51

	/* #546 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554631
	/* java_name */
	.ascii	"com/rscja/deviceapi/service/BLEService$IDataCallBack"
	.zero	37

	/* #547 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554632
	/* java_name */
	.ascii	"com/rscja/deviceapi/service/BTService"
	.zero	52

	/* #548 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554634
	/* java_name */
	.ascii	"com/rscja/deviceapi/service/BTService$IDataCallBack"
	.zero	38

	/* #549 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554626
	/* java_name */
	.ascii	"com/rscja/deviceapi/usb/USBUtil"
	.zero	58

	/* #550 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554627
	/* java_name */
	.ascii	"com/rscja/deviceapi/usb/USBUtil$ReceiverData"
	.zero	45

	/* #551 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554628
	/* java_name */
	.ascii	"com/rscja/deviceapi/usb/USBUtil$UsbReceiver"
	.zero	46

	/* #552 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554485
	/* java_name */
	.ascii	"com/rscja/utility/StringUtility"
	.zero	58

	/* #553 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554479
	/* java_name */
	.ascii	"com/scanner/IScanner"
	.zero	69

	/* #554 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554483
	/* java_name */
	.ascii	"com/scanner/utility/ScannerUtility"
	.zero	55

	/* #555 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"com/toptoche/searchablespinnerlibrary/BuildConfig"
	.zero	40

	/* #556 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554436
	/* java_name */
	.ascii	"com/toptoche/searchablespinnerlibrary/SearchableListDialog"
	.zero	31

	/* #557 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"com/toptoche/searchablespinnerlibrary/SearchableListDialog$OnSearchTextChanged"
	.zero	11

	/* #558 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"com/toptoche/searchablespinnerlibrary/SearchableListDialog$SearchableItem"
	.zero	16

	/* #559 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"com/toptoche/searchablespinnerlibrary/SearchableSpinner"
	.zero	34

	/* #560 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554450
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader"
	.zero	54

	/* #561 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554452
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$AutoFocusCallback"
	.zero	36

	/* #562 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554454
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$DecodeCallback"
	.zero	39

	/* #563 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554456
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$ErrorCallback"
	.zero	40

	/* #564 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554457
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$EventHandler"
	.zero	41

	/* #565 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554459
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$OnZoomChangeListener"
	.zero	33

	/* #566 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554462
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$ParamNum"
	.zero	45

	/* #567 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554463
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$ParamVal"
	.zero	45

	/* #568 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554464
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$Parameters"
	.zero	43

	/* #569 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554466
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$PictureCallback"
	.zero	38

	/* #570 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554468
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$PreviewCallback"
	.zero	38

	/* #571 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554469
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$PropertyNum"
	.zero	42

	/* #572 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554470
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$ReaderInfo"
	.zero	43

	/* #573 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554471
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$Size"
	.zero	49

	/* #574 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554473
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$VideoCallback"
	.zero	40

	/* #575 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft"
	.zero	50

	/* #576 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554436
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$CODETYPE"
	.zero	41

	/* #577 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$HardwareType"
	.zero	37

	/* #578 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$PictureCallback"
	.zero	34

	/* #579 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ResultDataBroadcastReceiver"
	.zero	22

	/* #580 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ScanCallback"
	.zero	37

	/* #581 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554443
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ScanerParamNum"
	.zero	35

	/* #582 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554444
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ScanerParamVal"
	.zero	35

	/* #583 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554445
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ScanerPropertyNum"
	.zero	32

	/* #584 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554446
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ThreadGC"
	.zero	41

	/* #585 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554447
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ThreadScan"
	.zero	39

	/* #586 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554449
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$VideoCallback"
	.zero	36

	/* #587 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554476
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Config"
	.zero	61

	/* #588 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554477
	/* java_name */
	.ascii	"com/zebra/adc/decoder/SymbologyConfiguration"
	.zero	45

	/* #589 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554478
	/* java_name */
	.ascii	"com/zebra/adc/decoder/SymbologyConfiguration$BarcodeSymbologyID"
	.zero	26

	/* #590 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554455
	/* java_name */
	.ascii	"crc642c0ac0281e969425/BarcodeDataReceiver"
	.zero	48

	/* #591 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554445
	/* java_name */
	.ascii	"crc64350623dcb797cc38/AndroidHttpClientAdapter"
	.zero	43

	/* #592 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554447
	/* java_name */
	.ascii	"crc64350623dcb797cc38/ServiceCall"
	.zero	56

	/* #593 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554434
	/* java_name */
	.ascii	"crc648a7c9d6e188cbaff/DatePickerFragment"
	.zero	49

	/* #594 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554548
	/* java_name */
	.ascii	"crc649b1ee189de92b663/CheckStockAddonAdapter"
	.zero	45

	/* #595 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554552
	/* java_name */
	.ascii	"crc649b1ee189de92b663/InterWarehouseEnteredPositionViewAdapter"
	.zero	27

	/* #596 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554553
	/* java_name */
	.ascii	"crc649b1ee189de92b663/InterwarehousSerialOrSCCCEntryAdapter"
	.zero	30

	/* #597 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554555
	/* java_name */
	.ascii	"crc649b1ee189de92b663/IssuedEnterAdapter"
	.zero	49

	/* #598 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554560
	/* java_name */
	.ascii	"crc649b1ee189de92b663/ProductionEnteredPositionViewAdapter"
	.zero	31

	/* #599 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554561
	/* java_name */
	.ascii	"crc649b1ee189de92b663/ProductionSerialOrSSCCAdapter"
	.zero	38

	/* #600 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554565
	/* java_name */
	.ascii	"crc649b1ee189de92b663/TakeOverEnteredPositionsViewAdapter"
	.zero	32

	/* #601 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554567
	/* java_name */
	.ascii	"crc649b1ee189de92b663/TakeOverIdentAdapter"
	.zero	47

	/* #602 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554569
	/* java_name */
	.ascii	"crc649b1ee189de92b663/TakeOverSerialOrSSCCEntryAdapter"
	.zero	35

	/* #603 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554582
	/* java_name */
	.ascii	"crc649b1ee189de92b663/UnfinishedInterwarehouseAdapter"
	.zero	36

	/* #604 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554571
	/* java_name */
	.ascii	"crc649b1ee189de92b663/UnfinishedIssuedAdapter"
	.zero	44

	/* #605 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554573
	/* java_name */
	.ascii	"crc649b1ee189de92b663/UnfinishedPackagingAdapter"
	.zero	41

	/* #606 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554575
	/* java_name */
	.ascii	"crc649b1ee189de92b663/UnfinishedProductionAdapter"
	.zero	40

	/* #607 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554584
	/* java_name */
	.ascii	"crc649b1ee189de92b663/UnfinishedTakeoverAdapter"
	.zero	42

	/* #608 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554546
	/* java_name */
	.ascii	"crc649b1ee189de92b663/adapter"
	.zero	60

	/* #609 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554547
	/* java_name */
	.ascii	"crc649b1ee189de92b663/adapterListViewItem"
	.zero	48

	/* #610 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554558
	/* java_name */
	.ascii	"crc649b1ee189de92b663/packagingListAdapter"
	.zero	47

	/* #611 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554563
	/* java_name */
	.ascii	"crc649b1ee189de92b663/rapidTakeoverAdapter"
	.zero	47

	/* #612 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554448
	/* java_name */
	.ascii	"crc64a0e0a82d0db9a07d/ActivityLifecycleContextListener"
	.zero	35

	/* #613 */
	/* module_index */
	.word	16
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"crc64a4555f9f70c213ae/Crashes_AndroidCrashListener"
	.zero	39

	/* #614 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554468
	/* java_name */
	.ascii	"crc64eb18f8f28af2a9d8/DeepLinkActivity"
	.zero	51

	/* #615 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554469
	/* java_name */
	.ascii	"crc64eb18f8f28af2a9d8/DownloadManagerReceiver"
	.zero	44

	/* #616 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554456
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/CheckStock"
	.zero	57

	/* #617 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554457
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/CheckStockTablet"
	.zero	51

	/* #618 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554459
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InterWarehouseBusinessEventSetup"
	.zero	35

	/* #619 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554460
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InterWarehouseBusinessEventSetupTablet"
	.zero	29

	/* #620 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554461
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InterWarehouseEnteredPositionsView"
	.zero	33

	/* #621 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554462
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InterWarehouseEnteredPositionsViewTablet"
	.zero	27

	/* #622 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554463
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InterWarehouseSerialOrSSCCEntry"
	.zero	36

	/* #623 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554464
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InterWarehouseSerialOrSSCCEntryTablet"
	.zero	30

	/* #624 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554465
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryConfirm"
	.zero	51

	/* #625 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554466
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryConfirmTablet"
	.zero	45

	/* #626 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554467
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryMenu"
	.zero	54

	/* #627 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554468
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryOpen"
	.zero	54

	/* #628 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554469
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryOpenDocument"
	.zero	46

	/* #629 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554470
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryOpenDocumentTablet"
	.zero	40

	/* #630 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554471
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryOpenTablet"
	.zero	48

	/* #631 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554472
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryPrint"
	.zero	53

	/* #632 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554473
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryPrintTablet"
	.zero	47

	/* #633 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554474
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryProcess"
	.zero	51

	/* #634 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554475
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryProcessTablet"
	.zero	45

	/* #635 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554476
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsBusinessEventSetup"
	.zero	38

	/* #636 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554477
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsBusinessEventSetupTablet"
	.zero	32

	/* #637 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554478
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsEnteredPositionsView"
	.zero	36

	/* #638 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554479
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsEnteredPositionsViewTablet"
	.zero	30

	/* #639 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554480
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsIdentEntry"
	.zero	46

	/* #640 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554481
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsIdentEntryTablet"
	.zero	40

	/* #641 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554482
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsIdentEntryWithTrail"
	.zero	37

	/* #642 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554483
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsIdentEntryWithTrailTablet"
	.zero	31

	/* #643 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554484
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsSerialOrSSCCEntry"
	.zero	39

	/* #644 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554485
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsSerialOrSSCCEntryTablet"
	.zero	33

	/* #645 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554486
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/MainActivity"
	.zero	55

	/* #646 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554487
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/MainMenu"
	.zero	59

	/* #647 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554488
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/MainMenuTablet"
	.zero	53

	/* #648 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554489
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PackagingEnteredPositionsView"
	.zero	38

	/* #649 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554490
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PackagingEnteredPositionsViewTablet"
	.zero	32

	/* #650 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554491
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PackagingSetContext"
	.zero	48

	/* #651 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554492
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PackagingSetContextTablet"
	.zero	42

	/* #652 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554493
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PackagingUnit"
	.zero	54

	/* #653 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554494
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PackagingUnitList"
	.zero	50

	/* #654 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554495
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PackagingUnitListTablet"
	.zero	44

	/* #655 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554496
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PackagingUnitTablet"
	.zero	48

	/* #656 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554497
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingInputControl"
	.zero	47

	/* #657 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554498
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingInputControlTablet"
	.zero	41

	/* #658 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554499
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingMenu"
	.zero	55

	/* #659 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554500
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingOutputControl"
	.zero	46

	/* #660 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554501
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingOutputControlTablet"
	.zero	40

	/* #661 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554502
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingProcessControl"
	.zero	45

	/* #662 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554503
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingProcessControlTablet"
	.zero	39

	/* #663 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554504
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingReprintLabels"
	.zero	46

	/* #664 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554505
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingReprintLabelsTablet"
	.zero	40

	/* #665 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554506
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingSSCCCodes"
	.zero	50

	/* #666 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554507
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingSSCCCodesTablet"
	.zero	44

	/* #667 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554508
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionCard"
	.zero	53

	/* #668 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554509
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionCardTablet"
	.zero	47

	/* #669 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554510
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionEnteredPositionsView"
	.zero	37

	/* #670 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554511
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionEnteredPositionsViewTablet"
	.zero	31

	/* #671 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554512
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionPalette"
	.zero	50

	/* #672 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554513
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionPaletteTablet"
	.zero	44

	/* #673 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554514
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionSerialOrSSCCEntry"
	.zero	40

	/* #674 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554515
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionSerialOrSSCCEntryTablet"
	.zero	34

	/* #675 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554516
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionWorkOrderSetup"
	.zero	43

	/* #676 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554517
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionWorkOrderSetupTablet"
	.zero	37

	/* #677 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554518
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/RapidTakeover"
	.zero	54

	/* #678 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554519
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/RapidTakeoverPhone"
	.zero	49

	/* #679 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554522
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/SelectSubjectBeforeFinish"
	.zero	42

	/* #680 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554523
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/SelectSubjectBeforeFinishTablet"
	.zero	36

	/* #681 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554524
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/Settings"
	.zero	59

	/* #682 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554525
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOver2Main"
	.zero	54

	/* #683 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554526
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOver2MainTablet"
	.zero	48

	/* #684 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554527
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOver2Orders"
	.zero	52

	/* #685 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554528
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOver2OrdersTablet"
	.zero	46

	/* #686 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554529
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOverBusinessEventSetup"
	.zero	41

	/* #687 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554530
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOverBusinessEventSetupTablet"
	.zero	35

	/* #688 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554531
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOverEnteredPositionsView"
	.zero	39

	/* #689 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554532
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOverEnteredPositionsViewTablet"
	.zero	33

	/* #690 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554533
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOverIdentEntry"
	.zero	49

	/* #691 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554534
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOverIdentEntryTablet"
	.zero	43

	/* #692 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554535
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOverSerialOrSSCCEntry"
	.zero	42

	/* #693 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554536
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOverSerialOrSSCCEntryTablet"
	.zero	36

	/* #694 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554537
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/UnfinishedInterWarehouseView"
	.zero	39

	/* #695 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554538
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/UnfinishedInterWarehouseViewTablet"
	.zero	33

	/* #696 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554539
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/UnfinishedIssuedGoodsView"
	.zero	42

	/* #697 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554540
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/UnfinishedIssuedGoodsViewTablet"
	.zero	36

	/* #698 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554541
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/UnfinishedProductionView"
	.zero	43

	/* #699 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554542
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/UnfinishedProductionViewTablet"
	.zero	37

	/* #700 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554543
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/UnfinishedTakeoversView"
	.zero	44

	/* #701 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554544
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/UnfinishedTakeoversViewTablet"
	.zero	38

	/* #702 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554458
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/choiceProduction"
	.zero	51

	/* #703 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554520
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/receiver"
	.zero	59

	/* #704 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554635
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/receiver_InitTask"
	.zero	50

	/* #705 */
	/* module_index */
	.word	17
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"crc64f378540348fc03ea/Distribute_Listener"
	.zero	48

	/* #706 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555147
	/* java_name */
	.ascii	"java/io/Closeable"
	.zero	72

	/* #707 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555143
	/* java_name */
	.ascii	"java/io/File"
	.zero	77

	/* #708 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555144
	/* java_name */
	.ascii	"java/io/FileDescriptor"
	.zero	67

	/* #709 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555145
	/* java_name */
	.ascii	"java/io/FileInputStream"
	.zero	66

	/* #710 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555149
	/* java_name */
	.ascii	"java/io/Flushable"
	.zero	72

	/* #711 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555153
	/* java_name */
	.ascii	"java/io/IOException"
	.zero	70

	/* #712 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555150
	/* java_name */
	.ascii	"java/io/InputStream"
	.zero	70

	/* #713 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555152
	/* java_name */
	.ascii	"java/io/InterruptedIOException"
	.zero	59

	/* #714 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555156
	/* java_name */
	.ascii	"java/io/OutputStream"
	.zero	69

	/* #715 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555158
	/* java_name */
	.ascii	"java/io/PrintWriter"
	.zero	70

	/* #716 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555155
	/* java_name */
	.ascii	"java/io/Serializable"
	.zero	69

	/* #717 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555159
	/* java_name */
	.ascii	"java/io/StringWriter"
	.zero	69

	/* #718 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555160
	/* java_name */
	.ascii	"java/io/Writer"
	.zero	75

	/* #719 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555098
	/* java_name */
	.ascii	"java/lang/AbstractStringBuilder"
	.zero	58

	/* #720 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555106
	/* java_name */
	.ascii	"java/lang/Appendable"
	.zero	69

	/* #721 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555108
	/* java_name */
	.ascii	"java/lang/AutoCloseable"
	.zero	66

	/* #722 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555075
	/* java_name */
	.ascii	"java/lang/Boolean"
	.zero	72

	/* #723 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555076
	/* java_name */
	.ascii	"java/lang/Byte"
	.zero	75

	/* #724 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555109
	/* java_name */
	.ascii	"java/lang/CharSequence"
	.zero	67

	/* #725 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555077
	/* java_name */
	.ascii	"java/lang/Character"
	.zero	70

	/* #726 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555078
	/* java_name */
	.ascii	"java/lang/Class"
	.zero	74

	/* #727 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555101
	/* java_name */
	.ascii	"java/lang/ClassCastException"
	.zero	61

	/* #728 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555079
	/* java_name */
	.ascii	"java/lang/ClassNotFoundException"
	.zero	57

	/* #729 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555112
	/* java_name */
	.ascii	"java/lang/Cloneable"
	.zero	70

	/* #730 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555114
	/* java_name */
	.ascii	"java/lang/Comparable"
	.zero	69

	/* #731 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555080
	/* java_name */
	.ascii	"java/lang/Double"
	.zero	73

	/* #732 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555102
	/* java_name */
	.ascii	"java/lang/Enum"
	.zero	75

	/* #733 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555104
	/* java_name */
	.ascii	"java/lang/Error"
	.zero	74

	/* #734 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555081
	/* java_name */
	.ascii	"java/lang/Exception"
	.zero	70

	/* #735 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555082
	/* java_name */
	.ascii	"java/lang/Float"
	.zero	74

	/* #736 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555117
	/* java_name */
	.ascii	"java/lang/IllegalArgumentException"
	.zero	55

	/* #737 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555118
	/* java_name */
	.ascii	"java/lang/IllegalStateException"
	.zero	58

	/* #738 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555119
	/* java_name */
	.ascii	"java/lang/IndexOutOfBoundsException"
	.zero	54

	/* #739 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555084
	/* java_name */
	.ascii	"java/lang/Integer"
	.zero	72

	/* #740 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555120
	/* java_name */
	.ascii	"java/lang/InterruptedException"
	.zero	59

	/* #741 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555116
	/* java_name */
	.ascii	"java/lang/Iterable"
	.zero	71

	/* #742 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555123
	/* java_name */
	.ascii	"java/lang/LinkageError"
	.zero	67

	/* #743 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555085
	/* java_name */
	.ascii	"java/lang/Long"
	.zero	75

	/* #744 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555124
	/* java_name */
	.ascii	"java/lang/NoClassDefFoundError"
	.zero	59

	/* #745 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555125
	/* java_name */
	.ascii	"java/lang/NullPointerException"
	.zero	59

	/* #746 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555126
	/* java_name */
	.ascii	"java/lang/Number"
	.zero	73

	/* #747 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555086
	/* java_name */
	.ascii	"java/lang/Object"
	.zero	73

	/* #748 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555128
	/* java_name */
	.ascii	"java/lang/ReflectiveOperationException"
	.zero	51

	/* #749 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555122
	/* java_name */
	.ascii	"java/lang/Runnable"
	.zero	71

	/* #750 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555087
	/* java_name */
	.ascii	"java/lang/RuntimeException"
	.zero	63

	/* #751 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555129
	/* java_name */
	.ascii	"java/lang/SecurityException"
	.zero	62

	/* #752 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555088
	/* java_name */
	.ascii	"java/lang/Short"
	.zero	74

	/* #753 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555130
	/* java_name */
	.ascii	"java/lang/StackTraceElement"
	.zero	62

	/* #754 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555089
	/* java_name */
	.ascii	"java/lang/String"
	.zero	73

	/* #755 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555091
	/* java_name */
	.ascii	"java/lang/StringBuffer"
	.zero	67

	/* #756 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555093
	/* java_name */
	.ascii	"java/lang/StringBuilder"
	.zero	66

	/* #757 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555095
	/* java_name */
	.ascii	"java/lang/Thread"
	.zero	73

	/* #758 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555097
	/* java_name */
	.ascii	"java/lang/Throwable"
	.zero	70

	/* #759 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555131
	/* java_name */
	.ascii	"java/lang/UnsupportedOperationException"
	.zero	50

	/* #760 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555132
	/* java_name */
	.ascii	"java/lang/Void"
	.zero	75

	/* #761 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555134
	/* java_name */
	.ascii	"java/lang/annotation/Annotation"
	.zero	58

	/* #762 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555136
	/* java_name */
	.ascii	"java/lang/reflect/AnnotatedElement"
	.zero	55

	/* #763 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555138
	/* java_name */
	.ascii	"java/lang/reflect/GenericDeclaration"
	.zero	53

	/* #764 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555140
	/* java_name */
	.ascii	"java/lang/reflect/Type"
	.zero	67

	/* #765 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555142
	/* java_name */
	.ascii	"java/lang/reflect/TypeVariable"
	.zero	59

	/* #766 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555001
	/* java_name */
	.ascii	"java/math/BigInteger"
	.zero	69

	/* #767 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554982
	/* java_name */
	.ascii	"java/net/ConnectException"
	.zero	64

	/* #768 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554984
	/* java_name */
	.ascii	"java/net/HttpURLConnection"
	.zero	63

	/* #769 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554986
	/* java_name */
	.ascii	"java/net/InetSocketAddress"
	.zero	63

	/* #770 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554987
	/* java_name */
	.ascii	"java/net/ProtocolException"
	.zero	63

	/* #771 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554988
	/* java_name */
	.ascii	"java/net/Proxy"
	.zero	75

	/* #772 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554989
	/* java_name */
	.ascii	"java/net/Proxy$Type"
	.zero	70

	/* #773 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554990
	/* java_name */
	.ascii	"java/net/ProxySelector"
	.zero	67

	/* #774 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554992
	/* java_name */
	.ascii	"java/net/SocketAddress"
	.zero	67

	/* #775 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554994
	/* java_name */
	.ascii	"java/net/SocketException"
	.zero	65

	/* #776 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554995
	/* java_name */
	.ascii	"java/net/SocketTimeoutException"
	.zero	58

	/* #777 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554997
	/* java_name */
	.ascii	"java/net/URI"
	.zero	77

	/* #778 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554998
	/* java_name */
	.ascii	"java/net/URL"
	.zero	77

	/* #779 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554999
	/* java_name */
	.ascii	"java/net/URLConnection"
	.zero	67

	/* #780 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554996
	/* java_name */
	.ascii	"java/net/UnknownServiceException"
	.zero	57

	/* #781 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555051
	/* java_name */
	.ascii	"java/nio/Buffer"
	.zero	74

	/* #782 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555053
	/* java_name */
	.ascii	"java/nio/ByteBuffer"
	.zero	70

	/* #783 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555058
	/* java_name */
	.ascii	"java/nio/channels/ByteChannel"
	.zero	60

	/* #784 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555060
	/* java_name */
	.ascii	"java/nio/channels/Channel"
	.zero	64

	/* #785 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555055
	/* java_name */
	.ascii	"java/nio/channels/FileChannel"
	.zero	60

	/* #786 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555062
	/* java_name */
	.ascii	"java/nio/channels/GatheringByteChannel"
	.zero	51

	/* #787 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555064
	/* java_name */
	.ascii	"java/nio/channels/InterruptibleChannel"
	.zero	51

	/* #788 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555066
	/* java_name */
	.ascii	"java/nio/channels/ReadableByteChannel"
	.zero	52

	/* #789 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555068
	/* java_name */
	.ascii	"java/nio/channels/ScatteringByteChannel"
	.zero	50

	/* #790 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555070
	/* java_name */
	.ascii	"java/nio/channels/SeekableByteChannel"
	.zero	52

	/* #791 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555072
	/* java_name */
	.ascii	"java/nio/channels/WritableByteChannel"
	.zero	52

	/* #792 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555073
	/* java_name */
	.ascii	"java/nio/channels/spi/AbstractInterruptibleChannel"
	.zero	39

	/* #793 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555033
	/* java_name */
	.ascii	"java/security/Key"
	.zero	72

	/* #794 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555036
	/* java_name */
	.ascii	"java/security/KeyStore"
	.zero	67

	/* #795 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555038
	/* java_name */
	.ascii	"java/security/KeyStore$LoadStoreParameter"
	.zero	48

	/* #796 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555040
	/* java_name */
	.ascii	"java/security/KeyStore$ProtectionParameter"
	.zero	47

	/* #797 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555035
	/* java_name */
	.ascii	"java/security/Principal"
	.zero	66

	/* #798 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555041
	/* java_name */
	.ascii	"java/security/SecureRandom"
	.zero	63

	/* #799 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555044
	/* java_name */
	.ascii	"java/security/cert/Certificate"
	.zero	59

	/* #800 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555046
	/* java_name */
	.ascii	"java/security/cert/CertificateFactory"
	.zero	52

	/* #801 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555049
	/* java_name */
	.ascii	"java/security/cert/X509Certificate"
	.zero	55

	/* #802 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555048
	/* java_name */
	.ascii	"java/security/cert/X509Extension"
	.zero	57

	/* #803 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555043
	/* java_name */
	.ascii	"java/security/spec/AlgorithmParameterSpec"
	.zero	48

	/* #804 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555002
	/* java_name */
	.ascii	"java/util/AbstractCollection"
	.zero	61

	/* #805 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555004
	/* java_name */
	.ascii	"java/util/AbstractList"
	.zero	67

	/* #806 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555006
	/* java_name */
	.ascii	"java/util/AbstractQueue"
	.zero	66

	/* #807 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554950
	/* java_name */
	.ascii	"java/util/ArrayList"
	.zero	70

	/* #808 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554939
	/* java_name */
	.ascii	"java/util/Collection"
	.zero	69

	/* #809 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555009
	/* java_name */
	.ascii	"java/util/Date"
	.zero	75

	/* #810 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555013
	/* java_name */
	.ascii	"java/util/Enumeration"
	.zero	68

	/* #811 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554941
	/* java_name */
	.ascii	"java/util/HashMap"
	.zero	72

	/* #812 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554959
	/* java_name */
	.ascii	"java/util/HashSet"
	.zero	72

	/* #813 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555015
	/* java_name */
	.ascii	"java/util/Iterator"
	.zero	71

	/* #814 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555017
	/* java_name */
	.ascii	"java/util/List"
	.zero	75

	/* #815 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555019
	/* java_name */
	.ascii	"java/util/ListIterator"
	.zero	67

	/* #816 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555021
	/* java_name */
	.ascii	"java/util/Queue"
	.zero	74

	/* #817 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555024
	/* java_name */
	.ascii	"java/util/Random"
	.zero	73

	/* #818 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555023
	/* java_name */
	.ascii	"java/util/RandomAccess"
	.zero	67

	/* #819 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555025
	/* java_name */
	.ascii	"java/util/TimerTask"
	.zero	70

	/* #820 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555027
	/* java_name */
	.ascii	"java/util/UUID"
	.zero	75

	/* #821 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555029
	/* java_name */
	.ascii	"java/util/concurrent/BlockingQueue"
	.zero	55

	/* #822 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555030
	/* java_name */
	.ascii	"java/util/concurrent/LinkedBlockingQueue"
	.zero	49

	/* #823 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555031
	/* java_name */
	.ascii	"java/util/concurrent/TimeUnit"
	.zero	60

	/* #824 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554563
	/* java_name */
	.ascii	"javax/net/SocketFactory"
	.zero	66

	/* #825 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554568
	/* java_name */
	.ascii	"javax/net/ssl/HostnameVerifier"
	.zero	59

	/* #826 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554565
	/* java_name */
	.ascii	"javax/net/ssl/HttpsURLConnection"
	.zero	57

	/* #827 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554570
	/* java_name */
	.ascii	"javax/net/ssl/KeyManager"
	.zero	65

	/* #828 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554579
	/* java_name */
	.ascii	"javax/net/ssl/KeyManagerFactory"
	.zero	58

	/* #829 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554580
	/* java_name */
	.ascii	"javax/net/ssl/SSLContext"
	.zero	65

	/* #830 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554572
	/* java_name */
	.ascii	"javax/net/ssl/SSLSession"
	.zero	65

	/* #831 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554574
	/* java_name */
	.ascii	"javax/net/ssl/SSLSessionContext"
	.zero	58

	/* #832 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554581
	/* java_name */
	.ascii	"javax/net/ssl/SSLSocketFactory"
	.zero	59

	/* #833 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554576
	/* java_name */
	.ascii	"javax/net/ssl/TrustManager"
	.zero	63

	/* #834 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554583
	/* java_name */
	.ascii	"javax/net/ssl/TrustManagerFactory"
	.zero	56

	/* #835 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554578
	/* java_name */
	.ascii	"javax/net/ssl/X509TrustManager"
	.zero	59

	/* #836 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554559
	/* java_name */
	.ascii	"javax/security/cert/Certificate"
	.zero	58

	/* #837 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554561
	/* java_name */
	.ascii	"javax/security/cert/X509Certificate"
	.zero	54

	/* #838 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555183
	/* java_name */
	.ascii	"mono/android/TypeManager"
	.zero	65

	/* #839 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554887
	/* java_name */
	.ascii	"mono/android/content/DialogInterface_OnClickListenerImplementor"
	.zero	26

	/* #840 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554934
	/* java_name */
	.ascii	"mono/android/runtime/InputStreamAdapter"
	.zero	50

	/* #841 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"mono/android/runtime/JavaArray"
	.zero	59

	/* #842 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554956
	/* java_name */
	.ascii	"mono/android/runtime/JavaObject"
	.zero	58

	/* #843 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554974
	/* java_name */
	.ascii	"mono/android/runtime/OutputStreamAdapter"
	.zero	49

	/* #844 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554445
	/* java_name */
	.ascii	"mono/android/support/v4/app/FragmentManager_OnBackStackChangedListenerImplementor"
	.zero	8

	/* #845 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"mono/android/support/v4/view/ActionProvider_SubUiVisibilityListenerImplementor"
	.zero	11

	/* #846 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554444
	/* java_name */
	.ascii	"mono/android/support/v4/view/ActionProvider_VisibilityListenerImplementor"
	.zero	16

	/* #847 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"mono/android/support/v4/widget/DrawerLayout_DrawerListenerImplementor"
	.zero	20

	/* #848 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"mono/android/support/v7/app/ActionBar_OnMenuVisibilityListenerImplementor"
	.zero	16

	/* #849 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554467
	/* java_name */
	.ascii	"mono/android/support/v7/widget/Toolbar_OnMenuItemClickListenerImplementor"
	.zero	16

	/* #850 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554655
	/* java_name */
	.ascii	"mono/android/view/View_OnClickListenerImplementor"
	.zero	40

	/* #851 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554661
	/* java_name */
	.ascii	"mono/android/view/View_OnFocusChangeListenerImplementor"
	.zero	34

	/* #852 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554665
	/* java_name */
	.ascii	"mono/android/view/View_OnKeyListenerImplementor"
	.zero	42

	/* #853 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554594
	/* java_name */
	.ascii	"mono/android/widget/AdapterView_OnItemClickListenerImplementor"
	.zero	27

	/* #854 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554598
	/* java_name */
	.ascii	"mono/android/widget/AdapterView_OnItemLongClickListenerImplementor"
	.zero	23

	/* #855 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554603
	/* java_name */
	.ascii	"mono/android/widget/AdapterView_OnItemSelectedListenerImplementor"
	.zero	24

	/* #856 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554711
	/* java_name */
	.ascii	"mono/com/hsm/barcode/DecoderListenerImplementor"
	.zero	42

	/* #857 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554458
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/analytics/channel/AnalyticsListenerImplementor"
	.zero	14

	/* #858 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554559
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/channel/Channel_GroupListenerImplementor"
	.zero	20

	/* #859 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554571
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/channel/Channel_ListenerImplementor"
	.zero	25

	/* #860 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554447
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/crashes/CrashesListenerImplementor"
	.zero	26

	/* #861 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554445
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/distribute/DistributeListenerImplementor"
	.zero	20

	/* #862 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554462
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/distribute/download/ReleaseDownloader_ListenerImplementor"
	.zero	3

	/* #863 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554464
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/utils/NetworkStateHelper_ListenerImplementor"
	.zero	16

	/* #864 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554483
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/utils/context/UserIdContext_ListenerImplementor"
	.zero	13

	/* #865 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554493
	/* java_name */
	.ascii	"mono/com/rscja/deviceapi/BDNavigation_BDLocationListenerImplementor"
	.zero	22

	/* #866 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554503
	/* java_name */
	.ascii	"mono/com/rscja/deviceapi/BDNavigation_BDStatusListenerImplementor"
	.zero	24

	/* #867 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554526
	/* java_name */
	.ascii	"mono/com/rscja/deviceapi/BluetoothReader_OnDataChangeListenerImplementor"
	.zero	17

	/* #868 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554461
	/* java_name */
	.ascii	"mono/com/zebra/adc/decoder/BarCodeReader_OnZoomChangeListenerImplementor"
	.zero	17

	/* #869 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33555096
	/* java_name */
	.ascii	"mono/java/lang/RunnableImplementor"
	.zero	55

	/* #870 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554557
	/* java_name */
	.ascii	"org/json/JSONObject"
	.zero	70

	/* #871 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554558
	/* java_name */
	.ascii	"org/json/JSONStringer"
	.zero	68

	/* #872 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554553
	/* java_name */
	.ascii	"xamarin/android/net/OldAndroidSSLSocketFactory"
	.zero	43

	.size	map_java, 84681
/* Java to managed map: END */

