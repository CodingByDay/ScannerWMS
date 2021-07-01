	.file	"typemaps.x86_64.s"

/* map_module_count: START */
	.section	.rodata.map_module_count,"a",@progbits
	.type	map_module_count, @object
	.p2align	2
	.global	map_module_count
map_module_count:
	.size	map_module_count, 4
	.long	20
/* map_module_count: END */

/* java_type_count: START */
	.section	.rodata.java_type_count,"a",@progbits
	.type	java_type_count, @object
	.p2align	2
	.global	java_type_count
java_type_count:
	.size	java_type_count, 4
	.long	877
/* java_type_count: END */

	.include	"typemaps.shared.inc"
	.include	"typemaps.x86_64-managed.inc"

/* Managed to Java map: START */
	.section	.data.rel.map_modules,"aw",@progbits
	.type	map_modules, @object
	.p2align	4
	.global	map_modules
map_modules:
	/* module_uuid: 4957a41d-8f26-4612-874e-235d435edbc3 */
	.byte	0x1d, 0xa4, 0x57, 0x49, 0x26, 0x8f, 0x12, 0x46, 0x87, 0x4e, 0x23, 0x5d, 0x43, 0x5e, 0xdb, 0xc3
	/* entry_count */
	.long	2
	/* duplicate_count */
	.long	0
	/* map */
	.quad	module0_managed_to_java
	/* duplicate_map */
	.quad	0
	/* assembly_name: Xamarin.Android.Arch.Lifecycle.ViewModel */
	.quad	.L.map_aname.0
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 77861822-459c-4261-8357-4fa39982e90b */
	.byte	0x22, 0x18, 0x86, 0x77, 0x9c, 0x45, 0x61, 0x42, 0x83, 0x57, 0x4f, 0xa3, 0x99, 0x82, 0xe9, 0x0b
	/* entry_count */
	.long	21
	/* duplicate_count */
	.long	3
	/* map */
	.quad	module1_managed_to_java
	/* duplicate_map */
	.quad	module1_managed_to_java_duplicates
	/* assembly_name: Microsoft.AppCenter.Distribute.Android.Bindings */
	.quad	.L.map_aname.1
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 95301626-037a-44e5-81a6-92748efc4329 */
	.byte	0x26, 0x16, 0x30, 0x95, 0x7a, 0x03, 0xe5, 0x44, 0x81, 0xa6, 0x92, 0x74, 0x8e, 0xfc, 0x43, 0x29
	/* entry_count */
	.long	97
	/* duplicate_count */
	.long	6
	/* map */
	.quad	module2_managed_to_java
	/* duplicate_map */
	.quad	module2_managed_to_java_duplicates
	/* assembly_name: Microsoft.AppCenter.Android.Bindings */
	.quad	.L.map_aname.2
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 8604c028-059f-4bcf-8084-8b0d6324fd31 */
	.byte	0x28, 0xc0, 0x04, 0x86, 0x9f, 0x05, 0xcf, 0x4b, 0x80, 0x84, 0x8b, 0x0d, 0x63, 0x24, 0xfd, 0x31
	/* entry_count */
	.long	2
	/* duplicate_count */
	.long	1
	/* map */
	.quad	module3_managed_to_java
	/* duplicate_map */
	.quad	module3_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Arch.Lifecycle.LiveData.Core */
	.quad	.L.map_aname.3
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: f2c9f139-e901-4f02-b54c-adacdc9e173c */
	.byte	0x39, 0xf1, 0xc9, 0xf2, 0x01, 0xe9, 0x02, 0x4f, 0xb5, 0x4c, 0xad, 0xac, 0xdc, 0x9e, 0x17, 0x3c
	/* entry_count */
	.long	18
	/* duplicate_count */
	.long	1
	/* map */
	.quad	module4_managed_to_java
	/* duplicate_map */
	.quad	module4_managed_to_java_duplicates
	/* assembly_name: Microsoft.AppCenter.Analytics.Android.Bindings */
	.quad	.L.map_aname.4
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: d2d48d48-c917-4ef4-ade9-c0b2be27f441 */
	.byte	0x48, 0x8d, 0xd4, 0xd2, 0x17, 0xc9, 0xf4, 0x4e, 0xad, 0xe9, 0xc0, 0xb2, 0xbe, 0x27, 0xf4, 0x41
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

	/* module_uuid: 6ba8025e-51e5-4faa-814f-ba127cda80df */
	.byte	0x5e, 0x02, 0xa8, 0x6b, 0xe5, 0x51, 0xaa, 0x4f, 0x81, 0x4f, 0xba, 0x12, 0x7c, 0xda, 0x80, 0xdf
	/* entry_count */
	.long	5
	/* duplicate_count */
	.long	1
	/* map */
	.quad	module6_managed_to_java
	/* duplicate_map */
	.quad	module6_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.Loader */
	.quad	.L.map_aname.6
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: a8521f7c-f475-4a1a-a81b-d008d81018c4 */
	.byte	0x7c, 0x1f, 0x52, 0xa8, 0x75, 0xf4, 0x1a, 0x4a, 0xa8, 0x1b, 0xd0, 0x08, 0xd8, 0x10, 0x18, 0xc4
	/* entry_count */
	.long	5
	/* duplicate_count */
	.long	0
	/* map */
	.quad	module7_managed_to_java
	/* duplicate_map */
	.quad	0
	/* assembly_name: EDMTBinding */
	.quad	.L.map_aname.7
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 4673017e-a9d5-46fb-8e60-1f165839f347 */
	.byte	0x7e, 0x01, 0x73, 0x46, 0xd5, 0xa9, 0xfb, 0x46, 0x8e, 0x60, 0x1f, 0x16, 0x58, 0x39, 0xf3, 0x47
	/* entry_count */
	.long	318
	/* duplicate_count */
	.long	164
	/* map */
	.quad	module8_managed_to_java
	/* duplicate_map */
	.quad	module8_managed_to_java_duplicates
	/* assembly_name: Mono.Android */
	.quad	.L.map_aname.8
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: af0c5186-cb1c-499f-a8bf-21b730c28eef */
	.byte	0x86, 0x51, 0x0c, 0xaf, 0x1c, 0xcb, 0x9f, 0x49, 0xa8, 0xbf, 0x21, 0xb7, 0x30, 0xc2, 0x8e, 0xef
	/* entry_count */
	.long	9
	/* duplicate_count */
	.long	3
	/* map */
	.quad	module9_managed_to_java
	/* duplicate_map */
	.quad	module9_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.Fragment */
	.quad	.L.map_aname.9
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: b1f7e38f-61fa-4239-9fbc-9e07465977ad */
	.byte	0x8f, 0xe3, 0xf7, 0xb1, 0xfa, 0x61, 0x39, 0x42, 0x9f, 0xbc, 0x9e, 0x07, 0x46, 0x59, 0x77, 0xad
	/* entry_count */
	.long	1
	/* duplicate_count */
	.long	0
	/* map */
	.quad	module10_managed_to_java
	/* duplicate_map */
	.quad	0
	/* assembly_name: Xamarin.Essentials */
	.quad	.L.map_aname.10
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 3bcec890-9d25-463b-b5e1-e5d68f8d8a41 */
	.byte	0x90, 0xc8, 0xce, 0x3b, 0x25, 0x9d, 0x3b, 0x46, 0xb5, 0xe1, 0xe5, 0xd6, 0x8f, 0x8d, 0x8a, 0x41
	/* entry_count */
	.long	30
	/* duplicate_count */
	.long	4
	/* map */
	.quad	module11_managed_to_java
	/* duplicate_map */
	.quad	module11_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.v7.AppCompat */
	.quad	.L.map_aname.11
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 3692d793-b1f5-4ae6-8334-1bd840aadfa9 */
	.byte	0x93, 0xd7, 0x92, 0x36, 0xf5, 0xb1, 0xe6, 0x4a, 0x83, 0x34, 0x1b, 0xd8, 0x40, 0xaa, 0xdf, 0xa9
	/* entry_count */
	.long	207
	/* duplicate_count */
	.long	7
	/* map */
	.quad	module12_managed_to_java
	/* duplicate_map */
	.quad	module12_managed_to_java_duplicates
	/* assembly_name: DeviceAPI */
	.quad	.L.map_aname.12
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 2b8100c8-4e0b-4580-88c6-1862bc31aef0 */
	.byte	0xc8, 0x00, 0x81, 0x2b, 0x0b, 0x4e, 0x80, 0x45, 0x88, 0xc6, 0x18, 0x62, 0xbc, 0x31, 0xae, 0xf0
	/* entry_count */
	.long	3
	/* duplicate_count */
	.long	0
	/* map */
	.quad	module13_managed_to_java
	/* duplicate_map */
	.quad	0
	/* assembly_name: Xamarin.Android.Support.DrawerLayout */
	.quad	.L.map_aname.13
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: edd9ebcd-4e65-4f04-9af6-56987a9c8986 */
	.byte	0xcd, 0xeb, 0xd9, 0xed, 0x65, 0x4e, 0x04, 0x4f, 0x9a, 0xf6, 0x56, 0x98, 0x7a, 0x9c, 0x89, 0x86
	/* entry_count */
	.long	1
	/* duplicate_count */
	.long	0
	/* map */
	.quad	module14_managed_to_java
	/* duplicate_map */
	.quad	0
	/* assembly_name: Microsoft.AppCenter.Crashes */
	.quad	.L.map_aname.14
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: be36facf-e235-47cc-a572-fdb5b8734b98 */
	.byte	0xcf, 0xfa, 0x36, 0xbe, 0x35, 0xe2, 0xcc, 0x47, 0xa5, 0x72, 0xfd, 0xb5, 0xb8, 0x73, 0x4b, 0x98
	/* entry_count */
	.long	1
	/* duplicate_count */
	.long	0
	/* map */
	.quad	module15_managed_to_java
	/* duplicate_map */
	.quad	0
	/* assembly_name: Microsoft.AppCenter.Distribute */
	.quad	.L.map_aname.15
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: ec09f3d4-7ab0-4d48-82bb-7c15721e9055 */
	.byte	0xd4, 0xf3, 0x09, 0xec, 0xb0, 0x7a, 0x48, 0x4d, 0x82, 0xbb, 0x7c, 0x15, 0x72, 0x1e, 0x90, 0x55
	/* entry_count */
	.long	21
	/* duplicate_count */
	.long	2
	/* map */
	.quad	module16_managed_to_java
	/* duplicate_map */
	.quad	module16_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Support.Compat */
	.quad	.L.map_aname.16
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 96d4c9d9-3766-4a1c-b1c0-9224898032c1 */
	.byte	0xd9, 0xc9, 0xd4, 0x96, 0x66, 0x37, 0x1c, 0x4a, 0xb1, 0xc0, 0x92, 0x24, 0x89, 0x80, 0x32, 0xc1
	/* entry_count */
	.long	113
	/* duplicate_count */
	.long	0
	/* map */
	.quad	module17_managed_to_java
	/* duplicate_map */
	.quad	0
	/* assembly_name: WMS */
	.quad	.L.map_aname.17
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: ba5f7cea-9978-4e63-83e2-ed7592ccd3af */
	.byte	0xea, 0x7c, 0x5f, 0xba, 0x78, 0x99, 0x63, 0x4e, 0x83, 0xe2, 0xed, 0x75, 0x92, 0xcc, 0xd3, 0xaf
	/* entry_count */
	.long	17
	/* duplicate_count */
	.long	2
	/* map */
	.quad	module18_managed_to_java
	/* duplicate_map */
	.quad	module18_managed_to_java_duplicates
	/* assembly_name: Microsoft.AppCenter.Crashes.Android.Bindings */
	.quad	.L.map_aname.18
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	/* module_uuid: 128a1af9-c153-42e4-b3ea-0553b0f85551 */
	.byte	0xf9, 0x1a, 0x8a, 0x12, 0x53, 0xc1, 0xe4, 0x42, 0xb3, 0xea, 0x05, 0x53, 0xb0, 0xf8, 0x55, 0x51
	/* entry_count */
	.long	4
	/* duplicate_count */
	.long	1
	/* map */
	.quad	module19_managed_to_java
	/* duplicate_map */
	.quad	module19_managed_to_java_duplicates
	/* assembly_name: Xamarin.Android.Arch.Lifecycle.Common */
	.quad	.L.map_aname.19
	/* image */
	.quad	0
	/* java_name_width */
	.long	0
	/* java_map */
	.zero	4
	.quad	0

	.size	map_modules, 1440
/* Managed to Java map: END */

/* Java to managed map: START */
	.section	.rodata.map_java,"a",@progbits
	.type	map_java, @object
	.p2align	4
	.global	map_java
map_java:
	/* #0 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554840
	/* java_name */
	.ascii	"android/animation/Animator"
	.zero	63
	.zero	1

	/* #1 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/animation/Animator$AnimatorListener"
	.zero	46
	.zero	1

	/* #2 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/animation/Animator$AnimatorPauseListener"
	.zero	41
	.zero	1

	/* #3 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554846
	/* java_name */
	.ascii	"android/animation/AnimatorListenerAdapter"
	.zero	48
	.zero	1

	/* #4 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/animation/TimeInterpolator"
	.zero	55
	.zero	1

	/* #5 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554851
	/* java_name */
	.ascii	"android/app/Activity"
	.zero	69
	.zero	1

	/* #6 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554852
	/* java_name */
	.ascii	"android/app/AlertDialog"
	.zero	66
	.zero	1

	/* #7 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554853
	/* java_name */
	.ascii	"android/app/AlertDialog$Builder"
	.zero	58
	.zero	1

	/* #8 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554854
	/* java_name */
	.ascii	"android/app/Application"
	.zero	66
	.zero	1

	/* #9 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/app/Application$ActivityLifecycleCallbacks"
	.zero	39
	.zero	1

	/* #10 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554857
	/* java_name */
	.ascii	"android/app/DatePickerDialog"
	.zero	61
	.zero	1

	/* #11 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/app/DatePickerDialog$OnDateSetListener"
	.zero	43
	.zero	1

	/* #12 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554860
	/* java_name */
	.ascii	"android/app/Dialog"
	.zero	71
	.zero	1

	/* #13 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554866
	/* java_name */
	.ascii	"android/app/DialogFragment"
	.zero	63
	.zero	1

	/* #14 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554867
	/* java_name */
	.ascii	"android/app/Fragment"
	.zero	69
	.zero	1

	/* #15 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554861
	/* java_name */
	.ascii	"android/app/FragmentManager"
	.zero	62
	.zero	1

	/* #16 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554869
	/* java_name */
	.ascii	"android/app/PendingIntent"
	.zero	64
	.zero	1

	/* #17 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554862
	/* java_name */
	.ascii	"android/app/ProgressDialog"
	.zero	63
	.zero	1

	/* #18 */
	/* module_index */
	.long	19
	/* type_token_id */
	.long	33554434
	/* java_name */
	.ascii	"android/arch/lifecycle/Lifecycle"
	.zero	57
	.zero	1

	/* #19 */
	/* module_index */
	.long	19
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"android/arch/lifecycle/Lifecycle$State"
	.zero	51
	.zero	1

	/* #20 */
	/* module_index */
	.long	19
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"android/arch/lifecycle/LifecycleObserver"
	.zero	49
	.zero	1

	/* #21 */
	/* module_index */
	.long	19
	/* type_token_id */
	.long	33554439
	/* java_name */
	.ascii	"android/arch/lifecycle/LifecycleOwner"
	.zero	52
	.zero	1

	/* #22 */
	/* module_index */
	.long	3
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"android/arch/lifecycle/LiveData"
	.zero	58
	.zero	1

	/* #23 */
	/* module_index */
	.long	3
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"android/arch/lifecycle/Observer"
	.zero	58
	.zero	1

	/* #24 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"android/arch/lifecycle/ViewModelStore"
	.zero	52
	.zero	1

	/* #25 */
	/* module_index */
	.long	0
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"android/arch/lifecycle/ViewModelStoreOwner"
	.zero	47
	.zero	1

	/* #26 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554837
	/* java_name */
	.ascii	"android/bluetooth/BluetoothDevice"
	.zero	56
	.zero	1

	/* #27 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554838
	/* java_name */
	.ascii	"android/bluetooth/BluetoothGattCharacteristic"
	.zero	44
	.zero	1

	/* #28 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554839
	/* java_name */
	.ascii	"android/bluetooth/BluetoothGattService"
	.zero	51
	.zero	1

	/* #29 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554874
	/* java_name */
	.ascii	"android/content/BroadcastReceiver"
	.zero	56
	.zero	1

	/* #30 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/content/ComponentCallbacks"
	.zero	55
	.zero	1

	/* #31 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/content/ComponentCallbacks2"
	.zero	54
	.zero	1

	/* #32 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554876
	/* java_name */
	.ascii	"android/content/ComponentName"
	.zero	60
	.zero	1

	/* #33 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554871
	/* java_name */
	.ascii	"android/content/Context"
	.zero	66
	.zero	1

	/* #34 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554878
	/* java_name */
	.ascii	"android/content/ContextWrapper"
	.zero	59
	.zero	1

	/* #35 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/content/DialogInterface"
	.zero	58
	.zero	1

	/* #36 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/content/DialogInterface$OnCancelListener"
	.zero	41
	.zero	1

	/* #37 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/content/DialogInterface$OnClickListener"
	.zero	42
	.zero	1

	/* #38 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/content/DialogInterface$OnDismissListener"
	.zero	40
	.zero	1

	/* #39 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554872
	/* java_name */
	.ascii	"android/content/Intent"
	.zero	67
	.zero	1

	/* #40 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554894
	/* java_name */
	.ascii	"android/content/IntentFilter"
	.zero	61
	.zero	1

	/* #41 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554895
	/* java_name */
	.ascii	"android/content/IntentSender"
	.zero	61
	.zero	1

	/* #42 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/content/SharedPreferences"
	.zero	56
	.zero	1

	/* #43 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/content/SharedPreferences$Editor"
	.zero	49
	.zero	1

	/* #44 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/content/SharedPreferences$OnSharedPreferenceChangeListener"
	.zero	23
	.zero	1

	/* #45 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554903
	/* java_name */
	.ascii	"android/content/pm/PackageInfo"
	.zero	59
	.zero	1

	/* #46 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554905
	/* java_name */
	.ascii	"android/content/pm/PackageManager"
	.zero	56
	.zero	1

	/* #47 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554909
	/* java_name */
	.ascii	"android/content/res/AssetManager"
	.zero	57
	.zero	1

	/* #48 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554910
	/* java_name */
	.ascii	"android/content/res/ColorStateList"
	.zero	55
	.zero	1

	/* #49 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554911
	/* java_name */
	.ascii	"android/content/res/Configuration"
	.zero	56
	.zero	1

	/* #50 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554912
	/* java_name */
	.ascii	"android/content/res/Resources"
	.zero	60
	.zero	1

	/* #51 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554913
	/* java_name */
	.ascii	"android/content/res/Resources$Theme"
	.zero	54
	.zero	1

	/* #52 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554588
	/* java_name */
	.ascii	"android/database/DataSetObserver"
	.zero	57
	.zero	1

	/* #53 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554817
	/* java_name */
	.ascii	"android/graphics/Bitmap"
	.zero	66
	.zero	1

	/* #54 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554821
	/* java_name */
	.ascii	"android/graphics/BitmapFactory"
	.zero	59
	.zero	1

	/* #55 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554822
	/* java_name */
	.ascii	"android/graphics/BitmapFactory$Options"
	.zero	51
	.zero	1

	/* #56 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554818
	/* java_name */
	.ascii	"android/graphics/Canvas"
	.zero	66
	.zero	1

	/* #57 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554823
	/* java_name */
	.ascii	"android/graphics/ColorFilter"
	.zero	61
	.zero	1

	/* #58 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554825
	/* java_name */
	.ascii	"android/graphics/Matrix"
	.zero	66
	.zero	1

	/* #59 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554826
	/* java_name */
	.ascii	"android/graphics/Paint"
	.zero	67
	.zero	1

	/* #60 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554827
	/* java_name */
	.ascii	"android/graphics/Point"
	.zero	67
	.zero	1

	/* #61 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554828
	/* java_name */
	.ascii	"android/graphics/PorterDuff"
	.zero	62
	.zero	1

	/* #62 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554829
	/* java_name */
	.ascii	"android/graphics/PorterDuff$Mode"
	.zero	57
	.zero	1

	/* #63 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554830
	/* java_name */
	.ascii	"android/graphics/Rect"
	.zero	68
	.zero	1

	/* #64 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554831
	/* java_name */
	.ascii	"android/graphics/RectF"
	.zero	67
	.zero	1

	/* #65 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554835
	/* java_name */
	.ascii	"android/graphics/drawable/BitmapDrawable"
	.zero	49
	.zero	1

	/* #66 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554832
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable"
	.zero	55
	.zero	1

	/* #67 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable$Callback"
	.zero	46
	.zero	1

	/* #68 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554815
	/* java_name */
	.ascii	"android/hardware/usb/UsbDevice"
	.zero	59
	.zero	1

	/* #69 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554813
	/* java_name */
	.ascii	"android/media/SoundPool"
	.zero	66
	.zero	1

	/* #70 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554809
	/* java_name */
	.ascii	"android/net/ConnectivityManager"
	.zero	58
	.zero	1

	/* #71 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554810
	/* java_name */
	.ascii	"android/net/NetworkInfo"
	.zero	66
	.zero	1

	/* #72 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554811
	/* java_name */
	.ascii	"android/net/Uri"
	.zero	74
	.zero	1

	/* #73 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/os/AsyncTask"
	.zero	69
	.zero	1

	/* #74 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554797
	/* java_name */
	.ascii	"android/os/BaseBundle"
	.zero	68
	.zero	1

	/* #75 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554798
	/* java_name */
	.ascii	"android/os/Build"
	.zero	73
	.zero	1

	/* #76 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554799
	/* java_name */
	.ascii	"android/os/Build$VERSION"
	.zero	65
	.zero	1

	/* #77 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554801
	/* java_name */
	.ascii	"android/os/Bundle"
	.zero	72
	.zero	1

	/* #78 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554794
	/* java_name */
	.ascii	"android/os/Handler"
	.zero	71
	.zero	1

	/* #79 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554806
	/* java_name */
	.ascii	"android/os/Looper"
	.zero	72
	.zero	1

	/* #80 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554807
	/* java_name */
	.ascii	"android/os/Parcel"
	.zero	72
	.zero	1

	/* #81 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/os/Parcelable"
	.zero	68
	.zero	1

	/* #82 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/os/Parcelable$Creator"
	.zero	60
	.zero	1

	/* #83 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554792
	/* java_name */
	.ascii	"android/preference/PreferenceManager"
	.zero	53
	.zero	1

	/* #84 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554960
	/* java_name */
	.ascii	"android/runtime/JavaProxyThrowable"
	.zero	55
	.zero	1

	/* #85 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554434
	/* java_name */
	.ascii	"android/support/v13/view/DragAndDropPermissionsCompat"
	.zero	36
	.zero	1

	/* #86 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554460
	/* java_name */
	.ascii	"android/support/v4/app/ActivityCompat"
	.zero	52
	.zero	1

	/* #87 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554462
	/* java_name */
	.ascii	"android/support/v4/app/ActivityCompat$OnRequestPermissionsResultCallback"
	.zero	17
	.zero	1

	/* #88 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554464
	/* java_name */
	.ascii	"android/support/v4/app/ActivityCompat$PermissionCompatDelegate"
	.zero	27
	.zero	1

	/* #89 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554466
	/* java_name */
	.ascii	"android/support/v4/app/ActivityCompat$RequestPermissionsRequestCodeValidator"
	.zero	13
	.zero	1

	/* #90 */
	/* module_index */
	.long	9
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"android/support/v4/app/Fragment"
	.zero	58
	.zero	1

	/* #91 */
	/* module_index */
	.long	9
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"android/support/v4/app/Fragment$SavedState"
	.zero	47
	.zero	1

	/* #92 */
	/* module_index */
	.long	9
	/* type_token_id */
	.long	33554434
	/* java_name */
	.ascii	"android/support/v4/app/FragmentActivity"
	.zero	50
	.zero	1

	/* #93 */
	/* module_index */
	.long	9
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"android/support/v4/app/FragmentManager"
	.zero	51
	.zero	1

	/* #94 */
	/* module_index */
	.long	9
	/* type_token_id */
	.long	33554439
	/* java_name */
	.ascii	"android/support/v4/app/FragmentManager$BackStackEntry"
	.zero	36
	.zero	1

	/* #95 */
	/* module_index */
	.long	9
	/* type_token_id */
	.long	33554440
	/* java_name */
	.ascii	"android/support/v4/app/FragmentManager$FragmentLifecycleCallbacks"
	.zero	24
	.zero	1

	/* #96 */
	/* module_index */
	.long	9
	/* type_token_id */
	.long	33554443
	/* java_name */
	.ascii	"android/support/v4/app/FragmentManager$OnBackStackChangedListener"
	.zero	24
	.zero	1

	/* #97 */
	/* module_index */
	.long	9
	/* type_token_id */
	.long	33554448
	/* java_name */
	.ascii	"android/support/v4/app/FragmentTransaction"
	.zero	47
	.zero	1

	/* #98 */
	/* module_index */
	.long	6
	/* type_token_id */
	.long	33554439
	/* java_name */
	.ascii	"android/support/v4/app/LoaderManager"
	.zero	53
	.zero	1

	/* #99 */
	/* module_index */
	.long	6
	/* type_token_id */
	.long	33554441
	/* java_name */
	.ascii	"android/support/v4/app/LoaderManager$LoaderCallbacks"
	.zero	37
	.zero	1

	/* #100 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554467
	/* java_name */
	.ascii	"android/support/v4/app/SharedElementCallback"
	.zero	45
	.zero	1

	/* #101 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554469
	/* java_name */
	.ascii	"android/support/v4/app/SharedElementCallback$OnSharedElementsReadyListener"
	.zero	15
	.zero	1

	/* #102 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554471
	/* java_name */
	.ascii	"android/support/v4/app/TaskStackBuilder"
	.zero	50
	.zero	1

	/* #103 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554473
	/* java_name */
	.ascii	"android/support/v4/app/TaskStackBuilder$SupportParentable"
	.zero	32
	.zero	1

	/* #104 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554458
	/* java_name */
	.ascii	"android/support/v4/content/ContextCompat"
	.zero	49
	.zero	1

	/* #105 */
	/* module_index */
	.long	6
	/* type_token_id */
	.long	33554434
	/* java_name */
	.ascii	"android/support/v4/content/Loader"
	.zero	56
	.zero	1

	/* #106 */
	/* module_index */
	.long	6
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"android/support/v4/content/Loader$OnLoadCanceledListener"
	.zero	33
	.zero	1

	/* #107 */
	/* module_index */
	.long	6
	/* type_token_id */
	.long	33554438
	/* java_name */
	.ascii	"android/support/v4/content/Loader$OnLoadCompleteListener"
	.zero	33
	.zero	1

	/* #108 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554459
	/* java_name */
	.ascii	"android/support/v4/content/pm/PackageInfoCompat"
	.zero	42
	.zero	1

	/* #109 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554455
	/* java_name */
	.ascii	"android/support/v4/internal/view/SupportMenu"
	.zero	45
	.zero	1

	/* #110 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554457
	/* java_name */
	.ascii	"android/support/v4/internal/view/SupportMenuItem"
	.zero	41
	.zero	1

	/* #111 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"android/support/v4/view/ActionProvider"
	.zero	51
	.zero	1

	/* #112 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"android/support/v4/view/ActionProvider$SubUiVisibilityListener"
	.zero	27
	.zero	1

	/* #113 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554441
	/* java_name */
	.ascii	"android/support/v4/view/ActionProvider$VisibilityListener"
	.zero	32
	.zero	1

	/* #114 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554453
	/* java_name */
	.ascii	"android/support/v4/view/ViewPropertyAnimatorCompat"
	.zero	39
	.zero	1

	/* #115 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554450
	/* java_name */
	.ascii	"android/support/v4/view/ViewPropertyAnimatorListener"
	.zero	37
	.zero	1

	/* #116 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554452
	/* java_name */
	.ascii	"android/support/v4/view/ViewPropertyAnimatorUpdateListener"
	.zero	31
	.zero	1

	/* #117 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554434
	/* java_name */
	.ascii	"android/support/v4/widget/DrawerLayout"
	.zero	51
	.zero	1

	/* #118 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"android/support/v4/widget/DrawerLayout$DrawerListener"
	.zero	36
	.zero	1

	/* #119 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar"
	.zero	57
	.zero	1

	/* #120 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$LayoutParams"
	.zero	44
	.zero	1

	/* #121 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554438
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$OnMenuVisibilityListener"
	.zero	32
	.zero	1

	/* #122 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554442
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$OnNavigationListener"
	.zero	36
	.zero	1

	/* #123 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554443
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$Tab"
	.zero	53
	.zero	1

	/* #124 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554446
	/* java_name */
	.ascii	"android/support/v7/app/ActionBar$TabListener"
	.zero	45
	.zero	1

	/* #125 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554450
	/* java_name */
	.ascii	"android/support/v7/app/ActionBarDrawerToggle"
	.zero	45
	.zero	1

	/* #126 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554452
	/* java_name */
	.ascii	"android/support/v7/app/ActionBarDrawerToggle$Delegate"
	.zero	36
	.zero	1

	/* #127 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554454
	/* java_name */
	.ascii	"android/support/v7/app/ActionBarDrawerToggle$DelegateProvider"
	.zero	28
	.zero	1

	/* #128 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554455
	/* java_name */
	.ascii	"android/support/v7/app/AppCompatActivity"
	.zero	49
	.zero	1

	/* #129 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554459
	/* java_name */
	.ascii	"android/support/v7/app/AppCompatCallback"
	.zero	49
	.zero	1

	/* #130 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554456
	/* java_name */
	.ascii	"android/support/v7/app/AppCompatDelegate"
	.zero	49
	.zero	1

	/* #131 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554434
	/* java_name */
	.ascii	"android/support/v7/graphics/drawable/DrawerArrowDrawable"
	.zero	33
	.zero	1

	/* #132 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554473
	/* java_name */
	.ascii	"android/support/v7/view/ActionMode"
	.zero	55
	.zero	1

	/* #133 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554475
	/* java_name */
	.ascii	"android/support/v7/view/ActionMode$Callback"
	.zero	46
	.zero	1

	/* #134 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554477
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuBuilder"
	.zero	49
	.zero	1

	/* #135 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554479
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuBuilder$Callback"
	.zero	40
	.zero	1

	/* #136 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554486
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuItemImpl"
	.zero	48
	.zero	1

	/* #137 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554483
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuPresenter"
	.zero	47
	.zero	1

	/* #138 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554481
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuPresenter$Callback"
	.zero	38
	.zero	1

	/* #139 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554485
	/* java_name */
	.ascii	"android/support/v7/view/menu/MenuView"
	.zero	52
	.zero	1

	/* #140 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554487
	/* java_name */
	.ascii	"android/support/v7/view/menu/SubMenuBuilder"
	.zero	46
	.zero	1

	/* #141 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554470
	/* java_name */
	.ascii	"android/support/v7/widget/DecorToolbar"
	.zero	51
	.zero	1

	/* #142 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554471
	/* java_name */
	.ascii	"android/support/v7/widget/ScrollingTabContainerView"
	.zero	38
	.zero	1

	/* #143 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554472
	/* java_name */
	.ascii	"android/support/v7/widget/ScrollingTabContainerView$VisibilityAnimListener"
	.zero	15
	.zero	1

	/* #144 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554460
	/* java_name */
	.ascii	"android/support/v7/widget/Toolbar"
	.zero	56
	.zero	1

	/* #145 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554464
	/* java_name */
	.ascii	"android/support/v7/widget/Toolbar$OnMenuItemClickListener"
	.zero	32
	.zero	1

	/* #146 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554461
	/* java_name */
	.ascii	"android/support/v7/widget/Toolbar_NavigationOnClickEventDispatcher"
	.zero	23
	.zero	1

	/* #147 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/text/Editable"
	.zero	68
	.zero	1

	/* #148 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/text/GetChars"
	.zero	68
	.zero	1

	/* #149 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/text/InputFilter"
	.zero	65
	.zero	1

	/* #150 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/text/NoCopySpan"
	.zero	66
	.zero	1

	/* #151 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/text/Spannable"
	.zero	67
	.zero	1

	/* #152 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/text/Spanned"
	.zero	69
	.zero	1

	/* #153 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/text/TextWatcher"
	.zero	65
	.zero	1

	/* #154 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/util/AttributeSet"
	.zero	64
	.zero	1

	/* #155 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554769
	/* java_name */
	.ascii	"android/util/DisplayMetrics"
	.zero	62
	.zero	1

	/* #156 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554768
	/* java_name */
	.ascii	"android/util/Log"
	.zero	73
	.zero	1

	/* #157 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554772
	/* java_name */
	.ascii	"android/util/SparseArray"
	.zero	65
	.zero	1

	/* #158 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554695
	/* java_name */
	.ascii	"android/view/ActionMode"
	.zero	66
	.zero	1

	/* #159 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/ActionMode$Callback"
	.zero	57
	.zero	1

	/* #160 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554700
	/* java_name */
	.ascii	"android/view/ActionProvider"
	.zero	62
	.zero	1

	/* #161 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/CollapsibleActionView"
	.zero	55
	.zero	1

	/* #162 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/ContextMenu"
	.zero	65
	.zero	1

	/* #163 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/ContextMenu$ContextMenuInfo"
	.zero	49
	.zero	1

	/* #164 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554702
	/* java_name */
	.ascii	"android/view/ContextThemeWrapper"
	.zero	57
	.zero	1

	/* #165 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554703
	/* java_name */
	.ascii	"android/view/Display"
	.zero	69
	.zero	1

	/* #166 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554704
	/* java_name */
	.ascii	"android/view/DragEvent"
	.zero	67
	.zero	1

	/* #167 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554720
	/* java_name */
	.ascii	"android/view/InputEvent"
	.zero	66
	.zero	1

	/* #168 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554676
	/* java_name */
	.ascii	"android/view/KeyEvent"
	.zero	68
	.zero	1

	/* #169 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/KeyEvent$Callback"
	.zero	59
	.zero	1

	/* #170 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554679
	/* java_name */
	.ascii	"android/view/LayoutInflater"
	.zero	62
	.zero	1

	/* #171 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/LayoutInflater$Factory"
	.zero	54
	.zero	1

	/* #172 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/LayoutInflater$Factory2"
	.zero	53
	.zero	1

	/* #173 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/Menu"
	.zero	72
	.zero	1

	/* #174 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554740
	/* java_name */
	.ascii	"android/view/MenuInflater"
	.zero	64
	.zero	1

	/* #175 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/MenuItem"
	.zero	68
	.zero	1

	/* #176 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/MenuItem$OnActionExpandListener"
	.zero	45
	.zero	1

	/* #177 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/MenuItem$OnMenuItemClickListener"
	.zero	44
	.zero	1

	/* #178 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554684
	/* java_name */
	.ascii	"android/view/MotionEvent"
	.zero	65
	.zero	1

	/* #179 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554743
	/* java_name */
	.ascii	"android/view/SearchEvent"
	.zero	65
	.zero	1

	/* #180 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/SubMenu"
	.zero	69
	.zero	1

	/* #181 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554746
	/* java_name */
	.ascii	"android/view/Surface"
	.zero	69
	.zero	1

	/* #182 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/SurfaceHolder"
	.zero	63
	.zero	1

	/* #183 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/SurfaceHolder$Callback"
	.zero	54
	.zero	1

	/* #184 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554654
	/* java_name */
	.ascii	"android/view/View"
	.zero	72
	.zero	1

	/* #185 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/View$OnClickListener"
	.zero	56
	.zero	1

	/* #186 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/View$OnCreateContextMenuListener"
	.zero	44
	.zero	1

	/* #187 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/View$OnFocusChangeListener"
	.zero	50
	.zero	1

	/* #188 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/View$OnKeyListener"
	.zero	58
	.zero	1

	/* #189 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/View$OnTouchListener"
	.zero	56
	.zero	1

	/* #190 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554750
	/* java_name */
	.ascii	"android/view/ViewGroup"
	.zero	67
	.zero	1

	/* #191 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554751
	/* java_name */
	.ascii	"android/view/ViewGroup$LayoutParams"
	.zero	54
	.zero	1

	/* #192 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554752
	/* java_name */
	.ascii	"android/view/ViewGroup$MarginLayoutParams"
	.zero	48
	.zero	1

	/* #193 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/ViewManager"
	.zero	65
	.zero	1

	/* #194 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/ViewParent"
	.zero	66
	.zero	1

	/* #195 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554754
	/* java_name */
	.ascii	"android/view/ViewPropertyAnimator"
	.zero	56
	.zero	1

	/* #196 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554685
	/* java_name */
	.ascii	"android/view/ViewTreeObserver"
	.zero	60
	.zero	1

	/* #197 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnGlobalLayoutListener"
	.zero	37
	.zero	1

	/* #198 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnPreDrawListener"
	.zero	42
	.zero	1

	/* #199 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnTouchModeChangeListener"
	.zero	34
	.zero	1

	/* #200 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554692
	/* java_name */
	.ascii	"android/view/Window"
	.zero	70
	.zero	1

	/* #201 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/Window$Callback"
	.zero	61
	.zero	1

	/* #202 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/WindowManager"
	.zero	63
	.zero	1

	/* #203 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554732
	/* java_name */
	.ascii	"android/view/WindowManager$LayoutParams"
	.zero	50
	.zero	1

	/* #204 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554761
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityEvent"
	.zero	44
	.zero	1

	/* #205 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityEventSource"
	.zero	38
	.zero	1

	/* #206 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554762
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityRecord"
	.zero	43
	.zero	1

	/* #207 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554757
	/* java_name */
	.ascii	"android/view/animation/Animation"
	.zero	57
	.zero	1

	/* #208 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/view/animation/Interpolator"
	.zero	54
	.zero	1

	/* #209 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554590
	/* java_name */
	.ascii	"android/widget/AbsListView"
	.zero	63
	.zero	1

	/* #210 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554618
	/* java_name */
	.ascii	"android/widget/AbsSpinner"
	.zero	64
	.zero	1

	/* #211 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/widget/Adapter"
	.zero	67
	.zero	1

	/* #212 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554592
	/* java_name */
	.ascii	"android/widget/AdapterView"
	.zero	63
	.zero	1

	/* #213 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/widget/AdapterView$OnItemClickListener"
	.zero	43
	.zero	1

	/* #214 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/widget/AdapterView$OnItemLongClickListener"
	.zero	39
	.zero	1

	/* #215 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/widget/AdapterView$OnItemSelectedListener"
	.zero	40
	.zero	1

	/* #216 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/widget/ArrayAdapter"
	.zero	62
	.zero	1

	/* #217 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554622
	/* java_name */
	.ascii	"android/widget/BaseAdapter"
	.zero	63
	.zero	1

	/* #218 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554624
	/* java_name */
	.ascii	"android/widget/Button"
	.zero	68
	.zero	1

	/* #219 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554614
	/* java_name */
	.ascii	"android/widget/DatePicker"
	.zero	64
	.zero	1

	/* #220 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/widget/DatePicker$OnDateChangedListener"
	.zero	42
	.zero	1

	/* #221 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554625
	/* java_name */
	.ascii	"android/widget/EditText"
	.zero	66
	.zero	1

	/* #222 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554626
	/* java_name */
	.ascii	"android/widget/Filter"
	.zero	68
	.zero	1

	/* #223 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/widget/Filter$FilterListener"
	.zero	53
	.zero	1

	/* #224 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/widget/Filterable"
	.zero	64
	.zero	1

	/* #225 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554630
	/* java_name */
	.ascii	"android/widget/FrameLayout"
	.zero	63
	.zero	1

	/* #226 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554631
	/* java_name */
	.ascii	"android/widget/HorizontalScrollView"
	.zero	54
	.zero	1

	/* #227 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554638
	/* java_name */
	.ascii	"android/widget/ImageView"
	.zero	65
	.zero	1

	/* #228 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554643
	/* java_name */
	.ascii	"android/widget/LinearLayout"
	.zero	62
	.zero	1

	/* #229 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/widget/ListAdapter"
	.zero	63
	.zero	1

	/* #230 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554644
	/* java_name */
	.ascii	"android/widget/ListView"
	.zero	66
	.zero	1

	/* #231 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554645
	/* java_name */
	.ascii	"android/widget/ProgressBar"
	.zero	63
	.zero	1

	/* #232 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554646
	/* java_name */
	.ascii	"android/widget/SearchView"
	.zero	64
	.zero	1

	/* #233 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/widget/SearchView$OnCloseListener"
	.zero	48
	.zero	1

	/* #234 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/widget/SearchView$OnQueryTextListener"
	.zero	44
	.zero	1

	/* #235 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554651
	/* java_name */
	.ascii	"android/widget/Spinner"
	.zero	67
	.zero	1

	/* #236 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/widget/SpinnerAdapter"
	.zero	60
	.zero	1

	/* #237 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554617
	/* java_name */
	.ascii	"android/widget/TextView"
	.zero	66
	.zero	1

	/* #238 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"android/widget/ThemedSpinnerAdapter"
	.zero	54
	.zero	1

	/* #239 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554652
	/* java_name */
	.ascii	"android/widget/Toast"
	.zero	69
	.zero	1

	/* #240 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554723
	/* java_name */
	.ascii	"com/barcode/BarcodeUtility"
	.zero	63
	.zero	1

	/* #241 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554724
	/* java_name */
	.ascii	"com/barcode/BarcodeUtility$ModuleType"
	.zero	52
	.zero	1

	/* #242 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554717
	/* java_name */
	.ascii	"com/custom/Barcode2DSoftHuace"
	.zero	60
	.zero	1

	/* #243 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554718
	/* java_name */
	.ascii	"com/custom/Barcode2DSoftHuace$Barcode2DScanCallback"
	.zero	38
	.zero	1

	/* #244 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554719
	/* java_name */
	.ascii	"com/custom/Barcode2DSoftHuace$Barcode2DScanCallback2"
	.zero	37
	.zero	1

	/* #245 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554721
	/* java_name */
	.ascii	"com/custom/BarcodeScanCallback"
	.zero	59
	.zero	1

	/* #246 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554722
	/* java_name */
	.ascii	"com/custom/RFIDWithUHFUARTUAE"
	.zero	60
	.zero	1

	/* #247 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554678
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeOptions"
	.zero	60
	.zero	1

	/* #248 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554692
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeResult"
	.zero	61
	.zero	1

	/* #249 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554695
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeWindowing"
	.zero	58
	.zero	1

	/* #250 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554696
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeWindowing$DecodeWindow"
	.zero	45
	.zero	1

	/* #251 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554697
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeWindowing$DecodeWindowLimits"
	.zero	39
	.zero	1

	/* #252 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554698
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeWindowing$DecodeWindowMode"
	.zero	41
	.zero	1

	/* #253 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554699
	/* java_name */
	.ascii	"com/hsm/barcode/DecodeWindowing$DecodeWindowShowWindow"
	.zero	35
	.zero	1

	/* #254 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554679
	/* java_name */
	.ascii	"com/hsm/barcode/Decoder"
	.zero	66
	.zero	1

	/* #255 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554684
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues"
	.zero	54
	.zero	1

	/* #256 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554685
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$EngineID"
	.zero	45
	.zero	1

	/* #257 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554686
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$EngineType"
	.zero	43
	.zero	1

	/* #258 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554687
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$LightsMode"
	.zero	43
	.zero	1

	/* #259 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554688
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$OCRMode"
	.zero	46
	.zero	1

	/* #260 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554689
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$OCRTemplate"
	.zero	42
	.zero	1

	/* #261 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554690
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$SymbologyFlags"
	.zero	39
	.zero	1

	/* #262 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554691
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderConfigValues$SymbologyID"
	.zero	42
	.zero	1

	/* #263 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554693
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderException"
	.zero	57
	.zero	1

	/* #264 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554694
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderException$ResultID"
	.zero	48
	.zero	1

	/* #265 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554708
	/* java_name */
	.ascii	"com/hsm/barcode/DecoderListener"
	.zero	58
	.zero	1

	/* #266 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554700
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues"
	.zero	59
	.zero	1

	/* #267 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554701
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues$ExposureMethod"
	.zero	44
	.zero	1

	/* #268 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554702
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues$ExposureMode"
	.zero	46
	.zero	1

	/* #269 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554703
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues$ExposureSettings"
	.zero	42
	.zero	1

	/* #270 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554704
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues$ExposureSettingsMinMax"
	.zero	36
	.zero	1

	/* #271 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554705
	/* java_name */
	.ascii	"com/hsm/barcode/ExposureValues$SpecularExclusion"
	.zero	41
	.zero	1

	/* #272 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554706
	/* java_name */
	.ascii	"com/hsm/barcode/HalInterface"
	.zero	61
	.zero	1

	/* #273 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554714
	/* java_name */
	.ascii	"com/hsm/barcode/IQImagingProperties"
	.zero	54
	.zero	1

	/* #274 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554715
	/* java_name */
	.ascii	"com/hsm/barcode/IQImagingProperties$IQImageFormat"
	.zero	40
	.zero	1

	/* #275 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554712
	/* java_name */
	.ascii	"com/hsm/barcode/ImageAttributes"
	.zero	58
	.zero	1

	/* #276 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554713
	/* java_name */
	.ascii	"com/hsm/barcode/ImagerProperties"
	.zero	57
	.zero	1

	/* #277 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554716
	/* java_name */
	.ascii	"com/hsm/barcode/SymbologyConfig"
	.zero	58
	.zero	1

	/* #278 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554672
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/AEData"
	.zero	53
	.zero	1

	/* #279 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554673
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/DetailData"
	.zero	49
	.zero	1

	/* #280 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554674
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/Result"
	.zero	53
	.zero	1

	/* #281 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554675
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/SaveMode"
	.zero	51
	.zero	1

	/* #282 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554676
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/SymbologyData"
	.zero	46
	.zero	1

	/* #283 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554677
	/* java_name */
	.ascii	"com/imagealgorithmlab/barcode/SymbologySettingItem"
	.zero	39
	.zero	1

	/* #284 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"com/microsoft/appcenter/AbstractAppCenterService"
	.zero	41
	.zero	1

	/* #285 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"com/microsoft/appcenter/AppCenter"
	.zero	56
	.zero	1

	/* #286 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554445
	/* java_name */
	.ascii	"com/microsoft/appcenter/AppCenterHandler"
	.zero	49
	.zero	1

	/* #287 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554447
	/* java_name */
	.ascii	"com/microsoft/appcenter/AppCenterService"
	.zero	49
	.zero	1

	/* #288 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554440
	/* java_name */
	.ascii	"com/microsoft/appcenter/BuildConfig"
	.zero	54
	.zero	1

	/* #289 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554441
	/* java_name */
	.ascii	"com/microsoft/appcenter/CancellationException"
	.zero	44
	.zero	1

	/* #290 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554442
	/* java_name */
	.ascii	"com/microsoft/appcenter/Constants"
	.zero	56
	.zero	1

	/* #291 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554438
	/* java_name */
	.ascii	"com/microsoft/appcenter/CustomProperties"
	.zero	49
	.zero	1

	/* #292 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554439
	/* java_name */
	.ascii	"com/microsoft/appcenter/DependencyConfiguration"
	.zero	42
	.zero	1

	/* #293 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554443
	/* java_name */
	.ascii	"com/microsoft/appcenter/Flags"
	.zero	60
	.zero	1

	/* #294 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/Analytics"
	.zero	46
	.zero	1

	/* #295 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/AnalyticsTransmissionTarget"
	.zero	28
	.zero	1

	/* #296 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/AuthenticationProvider"
	.zero	33
	.zero	1

	/* #297 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554439
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/AuthenticationProvider$AuthenticationCallback"
	.zero	10
	.zero	1

	/* #298 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554441
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/AuthenticationProvider$TokenProvider"
	.zero	19
	.zero	1

	/* #299 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554442
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/AuthenticationProvider$Type"
	.zero	28
	.zero	1

	/* #300 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554443
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/BuildConfig"
	.zero	44
	.zero	1

	/* #301 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554444
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/EventProperties"
	.zero	40
	.zero	1

	/* #302 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554445
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/PropertyConfigurator"
	.zero	35
	.zero	1

	/* #303 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554454
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/channel/AnalyticsListener"
	.zero	30
	.zero	1

	/* #304 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554452
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/channel/AnalyticsValidator"
	.zero	29
	.zero	1

	/* #305 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554459
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/channel/SessionTracker"
	.zero	33
	.zero	1

	/* #306 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554446
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/ingestion/models/EventLog"
	.zero	30
	.zero	1

	/* #307 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554447
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/ingestion/models/LogWithNameAndProperties"
	.zero	14
	.zero	1

	/* #308 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554449
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/ingestion/models/PageLog"
	.zero	31
	.zero	1

	/* #309 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554450
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/ingestion/models/StartSessionLog"
	.zero	23
	.zero	1

	/* #310 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554451
	/* java_name */
	.ascii	"com/microsoft/appcenter/analytics/ingestion/models/one/CommonSchemaEventLog"
	.zero	14
	.zero	1

	/* #311 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554553
	/* java_name */
	.ascii	"com/microsoft/appcenter/channel/AbstractChannelListener"
	.zero	34
	.zero	1

	/* #312 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554573
	/* java_name */
	.ascii	"com/microsoft/appcenter/channel/Channel"
	.zero	50
	.zero	1

	/* #313 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554555
	/* java_name */
	.ascii	"com/microsoft/appcenter/channel/Channel$GroupListener"
	.zero	36
	.zero	1

	/* #314 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554561
	/* java_name */
	.ascii	"com/microsoft/appcenter/channel/Channel$Listener"
	.zero	41
	.zero	1

	/* #315 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554574
	/* java_name */
	.ascii	"com/microsoft/appcenter/channel/OneCollectorChannelListener"
	.zero	30
	.zero	1

	/* #316 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/AbstractCrashesListener"
	.zero	34
	.zero	1

	/* #317 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554438
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/BuildConfig"
	.zero	46
	.zero	1

	/* #318 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/Crashes"
	.zero	50
	.zero	1

	/* #319 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554440
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/CrashesListener"
	.zero	42
	.zero	1

	/* #320 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554448
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/WrapperSdkExceptionManager"
	.zero	31
	.zero	1

	/* #321 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554453
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/AbstractErrorLog"
	.zero	24
	.zero	1

	/* #322 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554455
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/ErrorAttachmentLog"
	.zero	22
	.zero	1

	/* #323 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554456
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/Exception"
	.zero	31
	.zero	1

	/* #324 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554457
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/HandledErrorLog"
	.zero	25
	.zero	1

	/* #325 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554458
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/ManagedErrorLog"
	.zero	25
	.zero	1

	/* #326 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554459
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/StackFrame"
	.zero	30
	.zero	1

	/* #327 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554460
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/ingestion/models/Thread"
	.zero	34
	.zero	1

	/* #328 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554450
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/model/ErrorReport"
	.zero	40
	.zero	1

	/* #329 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554452
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/model/NativeException"
	.zero	36
	.zero	1

	/* #330 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554451
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/model/TestCrashException"
	.zero	33
	.zero	1

	/* #331 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554449
	/* java_name */
	.ascii	"com/microsoft/appcenter/crashes/utils/ErrorLogHelper"
	.zero	37
	.zero	1

	/* #332 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/BuildConfig"
	.zero	43
	.zero	1

	/* #333 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554438
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/DeepLinkActivity"
	.zero	38
	.zero	1

	/* #334 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/Distribute"
	.zero	44
	.zero	1

	/* #335 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554439
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/DistributeConstants"
	.zero	35
	.zero	1

	/* #336 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554442
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/DistributeListener"
	.zero	36
	.zero	1

	/* #337 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554440
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/DownloadManagerReceiver"
	.zero	31
	.zero	1

	/* #338 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554450
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/InstallerUtils"
	.zero	40
	.zero	1

	/* #339 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554451
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/PermissionUtils"
	.zero	39
	.zero	1

	/* #340 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/ReleaseDetails"
	.zero	40
	.zero	1

	/* #341 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554446
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/UpdateTrack"
	.zero	43
	.zero	1

	/* #342 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554467
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/channel/DistributeInfoTracker"
	.zero	25
	.zero	1

	/* #343 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554454
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/download/AbstractReleaseDownloader"
	.zero	20
	.zero	1

	/* #344 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554464
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/download/ReleaseDownloader"
	.zero	28
	.zero	1

	/* #345 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554457
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/download/ReleaseDownloader$Listener"
	.zero	19
	.zero	1

	/* #346 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554465
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/download/ReleaseDownloaderFactory"
	.zero	21
	.zero	1

	/* #347 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554466
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/download/manager/DownloadManagerReleaseDownloader"
	.zero	5
	.zero	1

	/* #348 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554453
	/* java_name */
	.ascii	"com/microsoft/appcenter/distribute/ingestion/models/DistributionStartSessionLog"
	.zero	10
	.zero	1

	/* #349 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554548
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/HttpClient"
	.zero	50
	.zero	1

	/* #350 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554546
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/HttpClient$CallTemplate"
	.zero	37
	.zero	1

	/* #351 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554543
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/HttpException"
	.zero	47
	.zero	1

	/* #352 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554544
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/HttpResponse"
	.zero	48
	.zero	1

	/* #353 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554550
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/ServiceCall"
	.zero	49
	.zero	1

	/* #354 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554552
	/* java_name */
	.ascii	"com/microsoft/appcenter/http/ServiceCallback"
	.zero	45
	.zero	1

	/* #355 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554489
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/AppCenterIngestion"
	.zero	37
	.zero	1

	/* #356 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554491
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/Ingestion"
	.zero	46
	.zero	1

	/* #357 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554492
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/OneCollectorIngestion"
	.zero	34
	.zero	1

	/* #358 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554493
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/AbstractLog"
	.zero	37
	.zero	1

	/* #359 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554495
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/CommonProperties"
	.zero	32
	.zero	1

	/* #360 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554496
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/CustomPropertiesLog"
	.zero	29
	.zero	1

	/* #361 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554497
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/Device"
	.zero	42
	.zero	1

	/* #362 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554499
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/Log"
	.zero	45
	.zero	1

	/* #363 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554502
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/LogContainer"
	.zero	36
	.zero	1

	/* #364 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554503
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/LogWithProperties"
	.zero	31
	.zero	1

	/* #365 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554501
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/Model"
	.zero	43
	.zero	1

	/* #366 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554505
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/StartServiceLog"
	.zero	33
	.zero	1

	/* #367 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554506
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/WrapperSdk"
	.zero	38
	.zero	1

	/* #368 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554530
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/AbstractLogFactory"
	.zero	25
	.zero	1

	/* #369 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554532
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/CustomPropertiesLogFactory"
	.zero	17
	.zero	1

	/* #370 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554533
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/DefaultLogSerializer"
	.zero	23
	.zero	1

	/* #371 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554540
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/JSONDateUtils"
	.zero	30
	.zero	1

	/* #372 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554541
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/JSONUtils"
	.zero	34
	.zero	1

	/* #373 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554535
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/LogFactory"
	.zero	33
	.zero	1

	/* #374 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554537
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/LogSerializer"
	.zero	30
	.zero	1

	/* #375 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554539
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/ModelFactory"
	.zero	31
	.zero	1

	/* #376 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554542
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/json/StartServiceLogFactory"
	.zero	21
	.zero	1

	/* #377 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554515
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/AppExtension"
	.zero	32
	.zero	1

	/* #378 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554516
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/CommonSchemaDataUtils"
	.zero	23
	.zero	1

	/* #379 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554517
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/CommonSchemaLog"
	.zero	29
	.zero	1

	/* #380 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554519
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/Data"
	.zero	40
	.zero	1

	/* #381 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554520
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/DeviceExtension"
	.zero	29
	.zero	1

	/* #382 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554521
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/Extensions"
	.zero	34
	.zero	1

	/* #383 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554522
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/LocExtension"
	.zero	32
	.zero	1

	/* #384 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554523
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/MetadataExtension"
	.zero	27
	.zero	1

	/* #385 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554524
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/NetExtension"
	.zero	32
	.zero	1

	/* #386 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554525
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/OsExtension"
	.zero	33
	.zero	1

	/* #387 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554526
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/PartAUtils"
	.zero	34
	.zero	1

	/* #388 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554527
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/ProtocolExtension"
	.zero	27
	.zero	1

	/* #389 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554528
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/SdkExtension"
	.zero	32
	.zero	1

	/* #390 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554529
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/one/UserExtension"
	.zero	31
	.zero	1

	/* #391 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554507
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/BooleanTypedProperty"
	.zero	17
	.zero	1

	/* #392 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554508
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/DateTimeTypedProperty"
	.zero	16
	.zero	1

	/* #393 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554509
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/DoubleTypedProperty"
	.zero	18
	.zero	1

	/* #394 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554510
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/LongTypedProperty"
	.zero	20
	.zero	1

	/* #395 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554511
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/StringTypedProperty"
	.zero	18
	.zero	1

	/* #396 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554512
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/TypedProperty"
	.zero	24
	.zero	1

	/* #397 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554514
	/* java_name */
	.ascii	"com/microsoft/appcenter/ingestion/models/properties/TypedPropertyUtils"
	.zero	19
	.zero	1

	/* #398 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554448
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/AppCenterLog"
	.zero	47
	.zero	1

	/* #399 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554449
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/AppNameHelper"
	.zero	46
	.zero	1

	/* #400 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554450
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/ApplicationLifecycleListener"
	.zero	31
	.zero	1

	/* #401 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554452
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/ApplicationLifecycleListener$ApplicationLifecycleCallbacks"
	.zero	1
	.zero	1

	/* #402 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554453
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/AsyncTaskUtils"
	.zero	45
	.zero	1

	/* #403 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554454
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/DeviceInfoHelper"
	.zero	43
	.zero	1

	/* #404 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554455
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/DeviceInfoHelper$DeviceInfoException"
	.zero	23
	.zero	1

	/* #405 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554456
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/HandlerUtils"
	.zero	47
	.zero	1

	/* #406 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554457
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/HashUtils"
	.zero	50
	.zero	1

	/* #407 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554458
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/IdHelper"
	.zero	51
	.zero	1

	/* #408 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554459
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/InstrumentationRegistryHelper"
	.zero	30
	.zero	1

	/* #409 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554460
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/NetworkStateHelper"
	.zero	41
	.zero	1

	/* #410 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554462
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/NetworkStateHelper$Listener"
	.zero	32
	.zero	1

	/* #411 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554465
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/PrefStorageConstants"
	.zero	39
	.zero	1

	/* #412 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554466
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/ShutdownHelper"
	.zero	45
	.zero	1

	/* #413 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554467
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/TicketCache"
	.zero	48
	.zero	1

	/* #414 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554486
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/async/AppCenterConsumer"
	.zero	36
	.zero	1

	/* #415 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554488
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/async/AppCenterFuture"
	.zero	38
	.zero	1

	/* #416 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554484
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/async/DefaultAppCenterFuture"
	.zero	31
	.zero	1

	/* #417 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554477
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/context/SessionContext"
	.zero	37
	.zero	1

	/* #418 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554478
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/context/SessionContext$SessionInfo"
	.zero	25
	.zero	1

	/* #419 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554479
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/context/UserIdContext"
	.zero	38
	.zero	1

	/* #420 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554481
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/context/UserIdContext$Listener"
	.zero	29
	.zero	1

	/* #421 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554468
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils"
	.zero	41
	.zero	1

	/* #422 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554469
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils$CryptoHandlerEntry"
	.zero	22
	.zero	1

	/* #423 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554470
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils$DecryptedData"
	.zero	27
	.zero	1

	/* #424 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554472
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils$ICipher"
	.zero	33
	.zero	1

	/* #425 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554474
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils$ICryptoFactory"
	.zero	26
	.zero	1

	/* #426 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554476
	/* java_name */
	.ascii	"com/microsoft/appcenter/utils/crypto/CryptoUtils$IKeyGenerator"
	.zero	27
	.zero	1

	/* #427 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554488
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation"
	.zero	57
	.zero	1

	/* #428 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554490
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$BDLocationListener"
	.zero	38
	.zero	1

	/* #429 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554494
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$BDProviderEnum"
	.zero	42
	.zero	1

	/* #430 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554495
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$BDStartModeEnum"
	.zero	41
	.zero	1

	/* #431 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554497
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$BDStatusListener"
	.zero	40
	.zero	1

	/* #432 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554504
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$ReadThread"
	.zero	46
	.zero	1

	/* #433 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554506
	/* java_name */
	.ascii	"com/rscja/deviceapi/BDNavigation$TestResultRawData"
	.zero	39
	.zero	1

	/* #434 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554486
	/* java_name */
	.ascii	"com/rscja/deviceapi/Barcode1D"
	.zero	60
	.zero	1

	/* #435 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554487
	/* java_name */
	.ascii	"com/rscja/deviceapi/Barcode2D"
	.zero	60
	.zero	1

	/* #436 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554520
	/* java_name */
	.ascii	"com/rscja/deviceapi/BluetoothReader"
	.zero	54
	.zero	1

	/* #437 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554522
	/* java_name */
	.ascii	"com/rscja/deviceapi/BluetoothReader$DataCallBack"
	.zero	41
	.zero	1

	/* #438 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554524
	/* java_name */
	.ascii	"com/rscja/deviceapi/BluetoothReader$OnDataChangeListener"
	.zero	33
	.zero	1

	/* #439 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554529
	/* java_name */
	.ascii	"com/rscja/deviceapi/CardWithBYL"
	.zero	58
	.zero	1

	/* #440 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554530
	/* java_name */
	.ascii	"com/rscja/deviceapi/Device"
	.zero	63
	.zero	1

	/* #441 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554532
	/* java_name */
	.ascii	"com/rscja/deviceapi/DeviceAPI"
	.zero	60
	.zero	1

	/* #442 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554533
	/* java_name */
	.ascii	"com/rscja/deviceapi/DeviceConfiguration"
	.zero	50
	.zero	1

	/* #443 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554534
	/* java_name */
	.ascii	"com/rscja/deviceapi/DeviceConfiguration$DeviceInfo"
	.zero	39
	.zero	1

	/* #444 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554535
	/* java_name */
	.ascii	"com/rscja/deviceapi/Fingerprint"
	.zero	58
	.zero	1

	/* #445 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554536
	/* java_name */
	.ascii	"com/rscja/deviceapi/Fingerprint$BufferEnum"
	.zero	47
	.zero	1

	/* #446 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554537
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS"
	.zero	50
	.zero	1

	/* #447 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554538
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$DataFormat"
	.zero	39
	.zero	1

	/* #448 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554540
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$EnrollCallBack"
	.zero	35
	.zero	1

	/* #449 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554541
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$FingerprintInfo"
	.zero	34
	.zero	1

	/* #450 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554543
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$GRABCallBack"
	.zero	37
	.zero	1

	/* #451 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554545
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$IdentificationCallBack"
	.zero	27
	.zero	1

	/* #452 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554547
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$PtCaptureCallBack"
	.zero	32
	.zero	1

	/* #453 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554549
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$TemplateVerifyCallBack"
	.zero	27
	.zero	1

	/* #454 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554550
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$ThreadEnroll"
	.zero	37
	.zero	1

	/* #455 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554551
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$ThreadGRAB"
	.zero	39
	.zero	1

	/* #456 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554552
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$ThreadIdentification"
	.zero	29
	.zero	1

	/* #457 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554553
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$ThreadPtCapture"
	.zero	34
	.zero	1

	/* #458 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554554
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithFIPS$ThreadTemplateVerify"
	.zero	29
	.zero	1

	/* #459 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554555
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho"
	.zero	48
	.zero	1

	/* #460 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554557
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$EnrollCallBack"
	.zero	33
	.zero	1

	/* #461 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554559
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$IdentificationCallBack"
	.zero	25
	.zero	1

	/* #462 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554560
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$MorphoMessage"
	.zero	34
	.zero	1

	/* #463 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554562
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$PtCaptureCallBack"
	.zero	30
	.zero	1

	/* #464 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554564
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$TemplateVerifyCallBack"
	.zero	25
	.zero	1

	/* #465 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554565
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$ThreadEnroll"
	.zero	35
	.zero	1

	/* #466 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554566
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$ThreadIdentification"
	.zero	27
	.zero	1

	/* #467 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554567
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$ThreadPtCapture"
	.zero	32
	.zero	1

	/* #468 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554568
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$ThreadPtCapturePKComp"
	.zero	26
	.zero	1

	/* #469 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554569
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$ThreadTemplateVerify"
	.zero	27
	.zero	1

	/* #470 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554570
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithMorpho$TimeOutThread"
	.zero	34
	.zero	1

	/* #471 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554571
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithZAZ"
	.zero	51
	.zero	1

	/* #472 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554572
	/* java_name */
	.ascii	"com/rscja/deviceapi/FingerprintWithZAZ$BufferEnum"
	.zero	40
	.zero	1

	/* #473 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554573
	/* java_name */
	.ascii	"com/rscja/deviceapi/Infrared"
	.zero	61
	.zero	1

	/* #474 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554574
	/* java_name */
	.ascii	"com/rscja/deviceapi/LedLight"
	.zero	61
	.zero	1

	/* #475 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554575
	/* java_name */
	.ascii	"com/rscja/deviceapi/Module"
	.zero	63
	.zero	1

	/* #476 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554582
	/* java_name */
	.ascii	"com/rscja/deviceapi/PSAM"
	.zero	65
	.zero	1

	/* #477 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554576
	/* java_name */
	.ascii	"com/rscja/deviceapi/Printer"
	.zero	62
	.zero	1

	/* #478 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554577
	/* java_name */
	.ascii	"com/rscja/deviceapi/Printer$BarcodeType"
	.zero	50
	.zero	1

	/* #479 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554578
	/* java_name */
	.ascii	"com/rscja/deviceapi/Printer$MeesageThread"
	.zero	48
	.zero	1

	/* #480 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554579
	/* java_name */
	.ascii	"com/rscja/deviceapi/Printer$PrinterStatus"
	.zero	48
	.zero	1

	/* #481 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554581
	/* java_name */
	.ascii	"com/rscja/deviceapi/Printer$PrinterStatusCallBack"
	.zero	40
	.zero	1

	/* #482 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554583
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDBase"
	.zero	61
	.zero	1

	/* #483 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554584
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A"
	.zero	52
	.zero	1

	/* #484 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554585
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A$DESFireEncryptionTypekEnum"
	.zero	25
	.zero	1

	/* #485 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554586
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A$DESFireFileTypekEnum"
	.zero	31
	.zero	1

	/* #486 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554587
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A$KeyType"
	.zero	44
	.zero	1

	/* #487 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554588
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A$TagType"
	.zero	44
	.zero	1

	/* #488 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554589
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443A4CPU"
	.zero	48
	.zero	1

	/* #489 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554590
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO14443B"
	.zero	52
	.zero	1

	/* #490 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554591
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO15693"
	.zero	53
	.zero	1

	/* #491 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554592
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithISO15693$TagType"
	.zero	45
	.zero	1

	/* #492 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554593
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithLF"
	.zero	59
	.zero	1

	/* #493 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554594
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF"
	.zero	58
	.zero	1

	/* #494 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554595
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF$BankEnum"
	.zero	49
	.zero	1

	/* #495 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554596
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF$LockModeEnum"
	.zero	45
	.zero	1

	/* #496 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554597
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF$SingelModeEnum"
	.zero	43
	.zero	1

	/* #497 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554598
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF$SingleModeEnum"
	.zero	43
	.zero	1

	/* #498 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554599
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHF706"
	.zero	55
	.zero	1

	/* #499 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554600
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFA8"
	.zero	56
	.zero	1

	/* #500 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554601
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFA8$NotifyThread"
	.zero	43
	.zero	1

	/* #501 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554602
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBLE"
	.zero	55
	.zero	1

	/* #502 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554604
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth"
	.zero	49
	.zero	1

	/* #503 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554606
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$BTStatusCallback"
	.zero	32
	.zero	1

	/* #504 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554607
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$BankEnum"
	.zero	40
	.zero	1

	/* #505 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554608
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$DataReceiveBTData"
	.zero	31
	.zero	1

	/* #506 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554610
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$KeyEventCallback"
	.zero	32
	.zero	1

	/* #507 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554612
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$ScanBTCallback"
	.zero	34
	.zero	1

	/* #508 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554613
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFBluetooth$StatusEnum"
	.zero	38
	.zero	1

	/* #509 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554614
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFUART"
	.zero	54
	.zero	1

	/* #510 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554616
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFUSB"
	.zero	55
	.zero	1

	/* #511 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554618
	/* java_name */
	.ascii	"com/rscja/deviceapi/RFIDWithUHFUSB$UsbReceiver"
	.zero	43
	.zero	1

	/* #512 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554621
	/* java_name */
	.ascii	"com/rscja/deviceapi/SPI"
	.zero	66
	.zero	1

	/* #513 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554619
	/* java_name */
	.ascii	"com/rscja/deviceapi/ScanerLedLight"
	.zero	55
	.zero	1

	/* #514 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554620
	/* java_name */
	.ascii	"com/rscja/deviceapi/ScanerLedLight$OffTask"
	.zero	47
	.zero	1

	/* #515 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554622
	/* java_name */
	.ascii	"com/rscja/deviceapi/UHFCustomAPI"
	.zero	57
	.zero	1

	/* #516 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554623
	/* java_name */
	.ascii	"com/rscja/deviceapi/UHFProtocolParse"
	.zero	53
	.zero	1

	/* #517 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554624
	/* java_name */
	.ascii	"com/rscja/deviceapi/UHFProtocolParseUSB"
	.zero	50
	.zero	1

	/* #518 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554625
	/* java_name */
	.ascii	"com/rscja/deviceapi/VersionInfo"
	.zero	58
	.zero	1

	/* #519 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554665
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/AnimalEntity"
	.zero	50
	.zero	1

	/* #520 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554666
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/BDLocation"
	.zero	52
	.zero	1

	/* #521 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554667
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/DESFireFile"
	.zero	51
	.zero	1

	/* #522 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554668
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/ISO15693Entity"
	.zero	48
	.zero	1

	/* #523 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554669
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/SatelliteEntity"
	.zero	47
	.zero	1

	/* #524 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554670
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/SimpleRFIDEntity"
	.zero	46
	.zero	1

	/* #525 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554671
	/* java_name */
	.ascii	"com/rscja/deviceapi/entity/UHFTAGInfo"
	.zero	52
	.zero	1

	/* #526 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554654
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/ConfigurationException"
	.zero	37
	.zero	1

	/* #527 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554655
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/DeviceNotConnectException"
	.zero	34
	.zero	1

	/* #528 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554656
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/FingerprintAlreadyEnrolledException"
	.zero	24
	.zero	1

	/* #529 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554657
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/FingerprintInvalidIDException"
	.zero	30
	.zero	1

	/* #530 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554660
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/PSAMException"
	.zero	46
	.zero	1

	/* #531 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554658
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/PrinterBarcodeInvalidException"
	.zero	29
	.zero	1

	/* #532 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554659
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/PrinterLowPager"
	.zero	44
	.zero	1

	/* #533 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554661
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/RFIDArgumentException"
	.zero	38
	.zero	1

	/* #534 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554662
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/RFIDNotFoundException"
	.zero	38
	.zero	1

	/* #535 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554663
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/RFIDReadFailureException"
	.zero	35
	.zero	1

	/* #536 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554664
	/* java_name */
	.ascii	"com/rscja/deviceapi/exception/RFIDVerificationException"
	.zero	34
	.zero	1

	/* #537 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554635
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/ConnectionStatus"
	.zero	42
	.zero	1

	/* #538 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554641
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/ConnectionStatusCallback"
	.zero	34
	.zero	1

	/* #539 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554636
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/IBluetoothReader"
	.zero	42
	.zero	1

	/* #540 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554646
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/IUHF"
	.zero	54
	.zero	1

	/* #541 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554651
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/IUHFProtocolParse"
	.zero	41
	.zero	1

	/* #542 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554653
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/IUhfReader"
	.zero	48
	.zero	1

	/* #543 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554643
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/KeyEventCallback"
	.zero	42
	.zero	1

	/* #544 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554645
	/* java_name */
	.ascii	"com/rscja/deviceapi/interfaces/ScanBTCallback"
	.zero	44
	.zero	1

	/* #545 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554629
	/* java_name */
	.ascii	"com/rscja/deviceapi/service/BLEService"
	.zero	51
	.zero	1

	/* #546 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554631
	/* java_name */
	.ascii	"com/rscja/deviceapi/service/BLEService$IDataCallBack"
	.zero	37
	.zero	1

	/* #547 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554632
	/* java_name */
	.ascii	"com/rscja/deviceapi/service/BTService"
	.zero	52
	.zero	1

	/* #548 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554634
	/* java_name */
	.ascii	"com/rscja/deviceapi/service/BTService$IDataCallBack"
	.zero	38
	.zero	1

	/* #549 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554626
	/* java_name */
	.ascii	"com/rscja/deviceapi/usb/USBUtil"
	.zero	58
	.zero	1

	/* #550 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554627
	/* java_name */
	.ascii	"com/rscja/deviceapi/usb/USBUtil$ReceiverData"
	.zero	45
	.zero	1

	/* #551 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554628
	/* java_name */
	.ascii	"com/rscja/deviceapi/usb/USBUtil$UsbReceiver"
	.zero	46
	.zero	1

	/* #552 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554485
	/* java_name */
	.ascii	"com/rscja/utility/StringUtility"
	.zero	58
	.zero	1

	/* #553 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554479
	/* java_name */
	.ascii	"com/scanner/IScanner"
	.zero	69
	.zero	1

	/* #554 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554483
	/* java_name */
	.ascii	"com/scanner/utility/ScannerUtility"
	.zero	55
	.zero	1

	/* #555 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"com/toptoche/searchablespinnerlibrary/BuildConfig"
	.zero	40
	.zero	1

	/* #556 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"com/toptoche/searchablespinnerlibrary/SearchableListDialog"
	.zero	31
	.zero	1

	/* #557 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554438
	/* java_name */
	.ascii	"com/toptoche/searchablespinnerlibrary/SearchableListDialog$OnSearchTextChanged"
	.zero	11
	.zero	1

	/* #558 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554440
	/* java_name */
	.ascii	"com/toptoche/searchablespinnerlibrary/SearchableListDialog$SearchableItem"
	.zero	16
	.zero	1

	/* #559 */
	/* module_index */
	.long	7
	/* type_token_id */
	.long	33554441
	/* java_name */
	.ascii	"com/toptoche/searchablespinnerlibrary/SearchableSpinner"
	.zero	34
	.zero	1

	/* #560 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554450
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader"
	.zero	54
	.zero	1

	/* #561 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554452
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$AutoFocusCallback"
	.zero	36
	.zero	1

	/* #562 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554454
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$DecodeCallback"
	.zero	39
	.zero	1

	/* #563 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554456
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$ErrorCallback"
	.zero	40
	.zero	1

	/* #564 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554457
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$EventHandler"
	.zero	41
	.zero	1

	/* #565 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554459
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$OnZoomChangeListener"
	.zero	33
	.zero	1

	/* #566 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554462
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$ParamNum"
	.zero	45
	.zero	1

	/* #567 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554463
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$ParamVal"
	.zero	45
	.zero	1

	/* #568 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554464
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$Parameters"
	.zero	43
	.zero	1

	/* #569 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554466
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$PictureCallback"
	.zero	38
	.zero	1

	/* #570 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554468
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$PreviewCallback"
	.zero	38
	.zero	1

	/* #571 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554469
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$PropertyNum"
	.zero	42
	.zero	1

	/* #572 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554470
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$ReaderInfo"
	.zero	43
	.zero	1

	/* #573 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554471
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$Size"
	.zero	49
	.zero	1

	/* #574 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554473
	/* java_name */
	.ascii	"com/zebra/adc/decoder/BarCodeReader$VideoCallback"
	.zero	40
	.zero	1

	/* #575 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft"
	.zero	50
	.zero	1

	/* #576 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$CODETYPE"
	.zero	41
	.zero	1

	/* #577 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554437
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$HardwareType"
	.zero	37
	.zero	1

	/* #578 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554439
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$PictureCallback"
	.zero	34
	.zero	1

	/* #579 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554440
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ResultDataBroadcastReceiver"
	.zero	22
	.zero	1

	/* #580 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554442
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ScanCallback"
	.zero	37
	.zero	1

	/* #581 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554443
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ScanerParamNum"
	.zero	35
	.zero	1

	/* #582 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554444
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ScanerParamVal"
	.zero	35
	.zero	1

	/* #583 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554445
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ScanerPropertyNum"
	.zero	32
	.zero	1

	/* #584 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554446
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ThreadGC"
	.zero	41
	.zero	1

	/* #585 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554447
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$ThreadScan"
	.zero	39
	.zero	1

	/* #586 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554449
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Barcode2DWithSoft$VideoCallback"
	.zero	36
	.zero	1

	/* #587 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554476
	/* java_name */
	.ascii	"com/zebra/adc/decoder/Config"
	.zero	61
	.zero	1

	/* #588 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554477
	/* java_name */
	.ascii	"com/zebra/adc/decoder/SymbologyConfiguration"
	.zero	45
	.zero	1

	/* #589 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554478
	/* java_name */
	.ascii	"com/zebra/adc/decoder/SymbologyConfiguration$BarcodeSymbologyID"
	.zero	26
	.zero	1

	/* #590 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554456
	/* java_name */
	.ascii	"crc642c0ac0281e969425/BarcodeDataReceiver"
	.zero	48
	.zero	1

	/* #591 */
	/* module_index */
	.long	5
	/* type_token_id */
	.long	33554445
	/* java_name */
	.ascii	"crc64350623dcb797cc38/AndroidHttpClientAdapter"
	.zero	43
	.zero	1

	/* #592 */
	/* module_index */
	.long	5
	/* type_token_id */
	.long	33554447
	/* java_name */
	.ascii	"crc64350623dcb797cc38/ServiceCall"
	.zero	56
	.zero	1

	/* #593 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554434
	/* java_name */
	.ascii	"crc648a7c9d6e188cbaff/DatePickerFragment"
	.zero	49
	.zero	1

	/* #594 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554436
	/* java_name */
	.ascii	"crc648a7c9d6e188cbaff/DialogAsync"
	.zero	56
	.zero	1

	/* #595 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554552
	/* java_name */
	.ascii	"crc649b1ee189de92b663/CheckStockAddonAdapter"
	.zero	45
	.zero	1

	/* #596 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554557
	/* java_name */
	.ascii	"crc649b1ee189de92b663/InterWarehouseEnteredPositionViewAdapter"
	.zero	27
	.zero	1

	/* #597 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554558
	/* java_name */
	.ascii	"crc649b1ee189de92b663/InterwarehousSerialOrSCCCEntryAdapter"
	.zero	30
	.zero	1

	/* #598 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554560
	/* java_name */
	.ascii	"crc649b1ee189de92b663/IssuedEnterAdapter"
	.zero	49
	.zero	1

	/* #599 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554565
	/* java_name */
	.ascii	"crc649b1ee189de92b663/ProductionEnteredPositionViewAdapter"
	.zero	31
	.zero	1

	/* #600 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554566
	/* java_name */
	.ascii	"crc649b1ee189de92b663/ProductionSerialOrSSCCAdapter"
	.zero	38
	.zero	1

	/* #601 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554570
	/* java_name */
	.ascii	"crc649b1ee189de92b663/TakeOverEnteredPositionsViewAdapter"
	.zero	32
	.zero	1

	/* #602 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554572
	/* java_name */
	.ascii	"crc649b1ee189de92b663/TakeOverIdentAdapter"
	.zero	47
	.zero	1

	/* #603 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554574
	/* java_name */
	.ascii	"crc649b1ee189de92b663/TakeOverSerialOrSSCCEntryAdapter"
	.zero	35
	.zero	1

	/* #604 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554587
	/* java_name */
	.ascii	"crc649b1ee189de92b663/UnfinishedInterwarehouseAdapter"
	.zero	36
	.zero	1

	/* #605 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554576
	/* java_name */
	.ascii	"crc649b1ee189de92b663/UnfinishedIssuedAdapter"
	.zero	44
	.zero	1

	/* #606 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554578
	/* java_name */
	.ascii	"crc649b1ee189de92b663/UnfinishedPackagingAdapter"
	.zero	41
	.zero	1

	/* #607 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554580
	/* java_name */
	.ascii	"crc649b1ee189de92b663/UnfinishedProductionAdapter"
	.zero	40
	.zero	1

	/* #608 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554589
	/* java_name */
	.ascii	"crc649b1ee189de92b663/UnfinishedTakeoverAdapter"
	.zero	42
	.zero	1

	/* #609 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554550
	/* java_name */
	.ascii	"crc649b1ee189de92b663/adapter"
	.zero	60
	.zero	1

	/* #610 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554551
	/* java_name */
	.ascii	"crc649b1ee189de92b663/adapterListViewItem"
	.zero	48
	.zero	1

	/* #611 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554563
	/* java_name */
	.ascii	"crc649b1ee189de92b663/packagingListAdapter"
	.zero	47
	.zero	1

	/* #612 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554568
	/* java_name */
	.ascii	"crc649b1ee189de92b663/rapidTakeoverAdapter"
	.zero	47
	.zero	1

	/* #613 */
	/* module_index */
	.long	10
	/* type_token_id */
	.long	33554448
	/* java_name */
	.ascii	"crc64a0e0a82d0db9a07d/ActivityLifecycleContextListener"
	.zero	35
	.zero	1

	/* #614 */
	/* module_index */
	.long	14
	/* type_token_id */
	.long	33554435
	/* java_name */
	.ascii	"crc64a4555f9f70c213ae/Crashes_AndroidCrashListener"
	.zero	39
	.zero	1

	/* #615 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554468
	/* java_name */
	.ascii	"crc64eb18f8f28af2a9d8/DeepLinkActivity"
	.zero	51
	.zero	1

	/* #616 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554469
	/* java_name */
	.ascii	"crc64eb18f8f28af2a9d8/DownloadManagerReceiver"
	.zero	44
	.zero	1

	/* #617 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554457
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/CheckStock"
	.zero	57
	.zero	1

	/* #618 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554458
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/CheckStockTablet"
	.zero	51
	.zero	1

	/* #619 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554460
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InterWarehouseBusinessEventSetup"
	.zero	35
	.zero	1

	/* #620 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554461
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InterWarehouseBusinessEventSetupTablet"
	.zero	29
	.zero	1

	/* #621 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554462
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InterWarehouseEnteredPositionsView"
	.zero	33
	.zero	1

	/* #622 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554463
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InterWarehouseEnteredPositionsViewTablet"
	.zero	27
	.zero	1

	/* #623 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554464
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InterWarehouseSerialOrSSCCEntry"
	.zero	36
	.zero	1

	/* #624 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554465
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InterWarehouseSerialOrSSCCEntryTablet"
	.zero	30
	.zero	1

	/* #625 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554466
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryConfirm"
	.zero	51
	.zero	1

	/* #626 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554467
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryConfirmTablet"
	.zero	45
	.zero	1

	/* #627 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554468
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryMenu"
	.zero	54
	.zero	1

	/* #628 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554469
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryOpen"
	.zero	54
	.zero	1

	/* #629 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554470
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryOpenDocument"
	.zero	46
	.zero	1

	/* #630 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554471
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryOpenDocumentTablet"
	.zero	40
	.zero	1

	/* #631 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554472
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryOpenTablet"
	.zero	48
	.zero	1

	/* #632 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554473
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryPrint"
	.zero	53
	.zero	1

	/* #633 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554474
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryPrintTablet"
	.zero	47
	.zero	1

	/* #634 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554475
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryProcess"
	.zero	51
	.zero	1

	/* #635 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554476
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/InventoryProcessTablet"
	.zero	45
	.zero	1

	/* #636 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554477
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsBusinessEventSetup"
	.zero	38
	.zero	1

	/* #637 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554478
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsBusinessEventSetupTablet"
	.zero	32
	.zero	1

	/* #638 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554479
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsEnteredPositionsView"
	.zero	36
	.zero	1

	/* #639 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554480
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsEnteredPositionsViewTablet"
	.zero	30
	.zero	1

	/* #640 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554481
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsIdentEntry"
	.zero	46
	.zero	1

	/* #641 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554482
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsIdentEntryTablet"
	.zero	40
	.zero	1

	/* #642 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554483
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsIdentEntryWithTrail"
	.zero	37
	.zero	1

	/* #643 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554484
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsIdentEntryWithTrailTablet"
	.zero	31
	.zero	1

	/* #644 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554485
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsSerialOrSSCCEntry"
	.zero	39
	.zero	1

	/* #645 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554486
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/IssuedGoodsSerialOrSSCCEntryTablet"
	.zero	33
	.zero	1

	/* #646 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554487
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/MainActivity"
	.zero	55
	.zero	1

	/* #647 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554488
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/MainMenu"
	.zero	59
	.zero	1

	/* #648 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554489
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/MainMenuTablet"
	.zero	53
	.zero	1

	/* #649 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554490
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/MenuPallets"
	.zero	56
	.zero	1

	/* #650 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554491
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PackagingEnteredPositionsView"
	.zero	38
	.zero	1

	/* #651 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554492
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PackagingEnteredPositionsViewTablet"
	.zero	32
	.zero	1

	/* #652 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554493
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PackagingSetContext"
	.zero	48
	.zero	1

	/* #653 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554494
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PackagingSetContextTablet"
	.zero	42
	.zero	1

	/* #654 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554495
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PackagingUnit"
	.zero	54
	.zero	1

	/* #655 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554496
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PackagingUnitList"
	.zero	50
	.zero	1

	/* #656 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554497
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PackagingUnitListTablet"
	.zero	44
	.zero	1

	/* #657 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554498
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PackagingUnitTablet"
	.zero	48
	.zero	1

	/* #658 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554499
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingInputControl"
	.zero	47
	.zero	1

	/* #659 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554500
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingInputControlTablet"
	.zero	41
	.zero	1

	/* #660 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554501
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingMenu"
	.zero	55
	.zero	1

	/* #661 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554502
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingOutputControl"
	.zero	46
	.zero	1

	/* #662 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554503
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingOutputControlTablet"
	.zero	40
	.zero	1

	/* #663 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554504
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingProcessControl"
	.zero	45
	.zero	1

	/* #664 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554505
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingProcessControlTablet"
	.zero	39
	.zero	1

	/* #665 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554506
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingReprintLabels"
	.zero	46
	.zero	1

	/* #666 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554507
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingReprintLabelsTablet"
	.zero	40
	.zero	1

	/* #667 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554508
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingSSCCCodes"
	.zero	50
	.zero	1

	/* #668 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554509
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/PrintingSSCCCodesTablet"
	.zero	44
	.zero	1

	/* #669 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554510
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionCard"
	.zero	53
	.zero	1

	/* #670 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554511
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionCardTablet"
	.zero	47
	.zero	1

	/* #671 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554512
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionEnteredPositionsView"
	.zero	37
	.zero	1

	/* #672 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554513
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionEnteredPositionsViewTablet"
	.zero	31
	.zero	1

	/* #673 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554514
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionPalette"
	.zero	50
	.zero	1

	/* #674 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554515
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionPaletteTablet"
	.zero	44
	.zero	1

	/* #675 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554516
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionSerialOrSSCCEntry"
	.zero	40
	.zero	1

	/* #676 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554517
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionSerialOrSSCCEntryTablet"
	.zero	34
	.zero	1

	/* #677 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554518
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionWorkOrderSetup"
	.zero	43
	.zero	1

	/* #678 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554519
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ProductionWorkOrderSetupTablet"
	.zero	37
	.zero	1

	/* #679 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554520
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/RapidTakeover"
	.zero	54
	.zero	1

	/* #680 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554521
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/RapidTakeoverPhone"
	.zero	49
	.zero	1

	/* #681 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554524
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/SelectSubjectBeforeFinish"
	.zero	42
	.zero	1

	/* #682 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554525
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/SelectSubjectBeforeFinishTablet"
	.zero	36
	.zero	1

	/* #683 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554526
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/Settings"
	.zero	59
	.zero	1

	/* #684 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554527
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/ShippingPallet"
	.zero	53
	.zero	1

	/* #685 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554528
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOver2Main"
	.zero	54
	.zero	1

	/* #686 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554529
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOver2MainTablet"
	.zero	48
	.zero	1

	/* #687 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554530
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOver2Orders"
	.zero	52
	.zero	1

	/* #688 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554531
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOver2OrdersTablet"
	.zero	46
	.zero	1

	/* #689 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554532
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOverBusinessEventSetup"
	.zero	41
	.zero	1

	/* #690 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554533
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOverBusinessEventSetupTablet"
	.zero	35
	.zero	1

	/* #691 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554534
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOverEnteredPositionsView"
	.zero	39
	.zero	1

	/* #692 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554535
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOverEnteredPositionsViewTablet"
	.zero	33
	.zero	1

	/* #693 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554536
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOverIdentEntry"
	.zero	49
	.zero	1

	/* #694 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554537
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOverIdentEntryTablet"
	.zero	43
	.zero	1

	/* #695 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554538
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOverSerialOrSSCCEntry"
	.zero	42
	.zero	1

	/* #696 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554539
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/TakeOverSerialOrSSCCEntryTablet"
	.zero	36
	.zero	1

	/* #697 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554540
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/UnfinishedInterWarehouseView"
	.zero	39
	.zero	1

	/* #698 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554541
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/UnfinishedInterWarehouseViewTablet"
	.zero	33
	.zero	1

	/* #699 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554542
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/UnfinishedIssuedGoodsView"
	.zero	42
	.zero	1

	/* #700 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554543
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/UnfinishedIssuedGoodsViewTablet"
	.zero	36
	.zero	1

	/* #701 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554544
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/UnfinishedProductionView"
	.zero	43
	.zero	1

	/* #702 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554545
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/UnfinishedProductionViewTablet"
	.zero	37
	.zero	1

	/* #703 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554546
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/UnfinishedTakeoversView"
	.zero	44
	.zero	1

	/* #704 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554547
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/UnfinishedTakeoversViewTablet"
	.zero	38
	.zero	1

	/* #705 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554548
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/WrappingPallet"
	.zero	53
	.zero	1

	/* #706 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554459
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/choiceProduction"
	.zero	51
	.zero	1

	/* #707 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554522
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/receiver"
	.zero	59
	.zero	1

	/* #708 */
	/* module_index */
	.long	17
	/* type_token_id */
	.long	33554659
	/* java_name */
	.ascii	"crc64f0e155b6502ec419/receiver_InitTask"
	.zero	50
	.zero	1

	/* #709 */
	/* module_index */
	.long	15
	/* type_token_id */
	.long	33554438
	/* java_name */
	.ascii	"crc64f378540348fc03ea/Distribute_Listener"
	.zero	48
	.zero	1

	/* #710 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/io/Closeable"
	.zero	72
	.zero	1

	/* #711 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555145
	/* java_name */
	.ascii	"java/io/File"
	.zero	77
	.zero	1

	/* #712 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555146
	/* java_name */
	.ascii	"java/io/FileDescriptor"
	.zero	67
	.zero	1

	/* #713 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555147
	/* java_name */
	.ascii	"java/io/FileInputStream"
	.zero	66
	.zero	1

	/* #714 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/io/Flushable"
	.zero	72
	.zero	1

	/* #715 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555155
	/* java_name */
	.ascii	"java/io/IOException"
	.zero	70
	.zero	1

	/* #716 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555152
	/* java_name */
	.ascii	"java/io/InputStream"
	.zero	70
	.zero	1

	/* #717 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555154
	/* java_name */
	.ascii	"java/io/InterruptedIOException"
	.zero	59
	.zero	1

	/* #718 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555158
	/* java_name */
	.ascii	"java/io/OutputStream"
	.zero	69
	.zero	1

	/* #719 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555160
	/* java_name */
	.ascii	"java/io/PrintWriter"
	.zero	70
	.zero	1

	/* #720 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/io/Serializable"
	.zero	69
	.zero	1

	/* #721 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555161
	/* java_name */
	.ascii	"java/io/StringWriter"
	.zero	69
	.zero	1

	/* #722 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555162
	/* java_name */
	.ascii	"java/io/Writer"
	.zero	75
	.zero	1

	/* #723 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555100
	/* java_name */
	.ascii	"java/lang/AbstractStringBuilder"
	.zero	58
	.zero	1

	/* #724 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/lang/Appendable"
	.zero	69
	.zero	1

	/* #725 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/lang/AutoCloseable"
	.zero	66
	.zero	1

	/* #726 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555077
	/* java_name */
	.ascii	"java/lang/Boolean"
	.zero	72
	.zero	1

	/* #727 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555078
	/* java_name */
	.ascii	"java/lang/Byte"
	.zero	75
	.zero	1

	/* #728 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/lang/CharSequence"
	.zero	67
	.zero	1

	/* #729 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555079
	/* java_name */
	.ascii	"java/lang/Character"
	.zero	70
	.zero	1

	/* #730 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555080
	/* java_name */
	.ascii	"java/lang/Class"
	.zero	74
	.zero	1

	/* #731 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555103
	/* java_name */
	.ascii	"java/lang/ClassCastException"
	.zero	61
	.zero	1

	/* #732 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555081
	/* java_name */
	.ascii	"java/lang/ClassNotFoundException"
	.zero	57
	.zero	1

	/* #733 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/lang/Cloneable"
	.zero	70
	.zero	1

	/* #734 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/lang/Comparable"
	.zero	69
	.zero	1

	/* #735 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555082
	/* java_name */
	.ascii	"java/lang/Double"
	.zero	73
	.zero	1

	/* #736 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555104
	/* java_name */
	.ascii	"java/lang/Enum"
	.zero	75
	.zero	1

	/* #737 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555106
	/* java_name */
	.ascii	"java/lang/Error"
	.zero	74
	.zero	1

	/* #738 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555083
	/* java_name */
	.ascii	"java/lang/Exception"
	.zero	70
	.zero	1

	/* #739 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555084
	/* java_name */
	.ascii	"java/lang/Float"
	.zero	74
	.zero	1

	/* #740 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555119
	/* java_name */
	.ascii	"java/lang/IllegalArgumentException"
	.zero	55
	.zero	1

	/* #741 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555120
	/* java_name */
	.ascii	"java/lang/IllegalStateException"
	.zero	58
	.zero	1

	/* #742 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555121
	/* java_name */
	.ascii	"java/lang/IndexOutOfBoundsException"
	.zero	54
	.zero	1

	/* #743 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555086
	/* java_name */
	.ascii	"java/lang/Integer"
	.zero	72
	.zero	1

	/* #744 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555122
	/* java_name */
	.ascii	"java/lang/InterruptedException"
	.zero	59
	.zero	1

	/* #745 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/lang/Iterable"
	.zero	71
	.zero	1

	/* #746 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555125
	/* java_name */
	.ascii	"java/lang/LinkageError"
	.zero	67
	.zero	1

	/* #747 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555087
	/* java_name */
	.ascii	"java/lang/Long"
	.zero	75
	.zero	1

	/* #748 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555126
	/* java_name */
	.ascii	"java/lang/NoClassDefFoundError"
	.zero	59
	.zero	1

	/* #749 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555127
	/* java_name */
	.ascii	"java/lang/NullPointerException"
	.zero	59
	.zero	1

	/* #750 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555128
	/* java_name */
	.ascii	"java/lang/Number"
	.zero	73
	.zero	1

	/* #751 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555088
	/* java_name */
	.ascii	"java/lang/Object"
	.zero	73
	.zero	1

	/* #752 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555130
	/* java_name */
	.ascii	"java/lang/ReflectiveOperationException"
	.zero	51
	.zero	1

	/* #753 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/lang/Runnable"
	.zero	71
	.zero	1

	/* #754 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555089
	/* java_name */
	.ascii	"java/lang/RuntimeException"
	.zero	63
	.zero	1

	/* #755 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555131
	/* java_name */
	.ascii	"java/lang/SecurityException"
	.zero	62
	.zero	1

	/* #756 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555090
	/* java_name */
	.ascii	"java/lang/Short"
	.zero	74
	.zero	1

	/* #757 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555132
	/* java_name */
	.ascii	"java/lang/StackTraceElement"
	.zero	62
	.zero	1

	/* #758 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555091
	/* java_name */
	.ascii	"java/lang/String"
	.zero	73
	.zero	1

	/* #759 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555093
	/* java_name */
	.ascii	"java/lang/StringBuffer"
	.zero	67
	.zero	1

	/* #760 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555095
	/* java_name */
	.ascii	"java/lang/StringBuilder"
	.zero	66
	.zero	1

	/* #761 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555097
	/* java_name */
	.ascii	"java/lang/Thread"
	.zero	73
	.zero	1

	/* #762 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555099
	/* java_name */
	.ascii	"java/lang/Throwable"
	.zero	70
	.zero	1

	/* #763 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555133
	/* java_name */
	.ascii	"java/lang/UnsupportedOperationException"
	.zero	50
	.zero	1

	/* #764 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555134
	/* java_name */
	.ascii	"java/lang/Void"
	.zero	75
	.zero	1

	/* #765 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/lang/annotation/Annotation"
	.zero	58
	.zero	1

	/* #766 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/lang/reflect/AnnotatedElement"
	.zero	55
	.zero	1

	/* #767 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/lang/reflect/GenericDeclaration"
	.zero	53
	.zero	1

	/* #768 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/lang/reflect/Type"
	.zero	67
	.zero	1

	/* #769 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/lang/reflect/TypeVariable"
	.zero	59
	.zero	1

	/* #770 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555003
	/* java_name */
	.ascii	"java/math/BigInteger"
	.zero	69
	.zero	1

	/* #771 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554984
	/* java_name */
	.ascii	"java/net/ConnectException"
	.zero	64
	.zero	1

	/* #772 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554986
	/* java_name */
	.ascii	"java/net/HttpURLConnection"
	.zero	63
	.zero	1

	/* #773 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554988
	/* java_name */
	.ascii	"java/net/InetSocketAddress"
	.zero	63
	.zero	1

	/* #774 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554989
	/* java_name */
	.ascii	"java/net/ProtocolException"
	.zero	63
	.zero	1

	/* #775 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554990
	/* java_name */
	.ascii	"java/net/Proxy"
	.zero	75
	.zero	1

	/* #776 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554991
	/* java_name */
	.ascii	"java/net/Proxy$Type"
	.zero	70
	.zero	1

	/* #777 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554992
	/* java_name */
	.ascii	"java/net/ProxySelector"
	.zero	67
	.zero	1

	/* #778 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554994
	/* java_name */
	.ascii	"java/net/SocketAddress"
	.zero	67
	.zero	1

	/* #779 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554996
	/* java_name */
	.ascii	"java/net/SocketException"
	.zero	65
	.zero	1

	/* #780 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554997
	/* java_name */
	.ascii	"java/net/SocketTimeoutException"
	.zero	58
	.zero	1

	/* #781 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554999
	/* java_name */
	.ascii	"java/net/URI"
	.zero	77
	.zero	1

	/* #782 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555000
	/* java_name */
	.ascii	"java/net/URL"
	.zero	77
	.zero	1

	/* #783 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555001
	/* java_name */
	.ascii	"java/net/URLConnection"
	.zero	67
	.zero	1

	/* #784 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554998
	/* java_name */
	.ascii	"java/net/UnknownServiceException"
	.zero	57
	.zero	1

	/* #785 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555053
	/* java_name */
	.ascii	"java/nio/Buffer"
	.zero	74
	.zero	1

	/* #786 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555055
	/* java_name */
	.ascii	"java/nio/ByteBuffer"
	.zero	70
	.zero	1

	/* #787 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/nio/channels/ByteChannel"
	.zero	60
	.zero	1

	/* #788 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/nio/channels/Channel"
	.zero	64
	.zero	1

	/* #789 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555057
	/* java_name */
	.ascii	"java/nio/channels/FileChannel"
	.zero	60
	.zero	1

	/* #790 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/nio/channels/GatheringByteChannel"
	.zero	51
	.zero	1

	/* #791 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/nio/channels/InterruptibleChannel"
	.zero	51
	.zero	1

	/* #792 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/nio/channels/ReadableByteChannel"
	.zero	52
	.zero	1

	/* #793 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/nio/channels/ScatteringByteChannel"
	.zero	50
	.zero	1

	/* #794 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/nio/channels/SeekableByteChannel"
	.zero	52
	.zero	1

	/* #795 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/nio/channels/WritableByteChannel"
	.zero	52
	.zero	1

	/* #796 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555075
	/* java_name */
	.ascii	"java/nio/channels/spi/AbstractInterruptibleChannel"
	.zero	39
	.zero	1

	/* #797 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/security/Key"
	.zero	72
	.zero	1

	/* #798 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555038
	/* java_name */
	.ascii	"java/security/KeyStore"
	.zero	67
	.zero	1

	/* #799 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/security/KeyStore$LoadStoreParameter"
	.zero	48
	.zero	1

	/* #800 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/security/KeyStore$ProtectionParameter"
	.zero	47
	.zero	1

	/* #801 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/security/Principal"
	.zero	66
	.zero	1

	/* #802 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555043
	/* java_name */
	.ascii	"java/security/SecureRandom"
	.zero	63
	.zero	1

	/* #803 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555046
	/* java_name */
	.ascii	"java/security/cert/Certificate"
	.zero	59
	.zero	1

	/* #804 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555048
	/* java_name */
	.ascii	"java/security/cert/CertificateFactory"
	.zero	52
	.zero	1

	/* #805 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555051
	/* java_name */
	.ascii	"java/security/cert/X509Certificate"
	.zero	55
	.zero	1

	/* #806 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/security/cert/X509Extension"
	.zero	57
	.zero	1

	/* #807 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/security/spec/AlgorithmParameterSpec"
	.zero	48
	.zero	1

	/* #808 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555004
	/* java_name */
	.ascii	"java/util/AbstractCollection"
	.zero	61
	.zero	1

	/* #809 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555006
	/* java_name */
	.ascii	"java/util/AbstractList"
	.zero	67
	.zero	1

	/* #810 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555008
	/* java_name */
	.ascii	"java/util/AbstractQueue"
	.zero	66
	.zero	1

	/* #811 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554952
	/* java_name */
	.ascii	"java/util/ArrayList"
	.zero	70
	.zero	1

	/* #812 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554941
	/* java_name */
	.ascii	"java/util/Collection"
	.zero	69
	.zero	1

	/* #813 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555011
	/* java_name */
	.ascii	"java/util/Date"
	.zero	75
	.zero	1

	/* #814 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/util/Enumeration"
	.zero	68
	.zero	1

	/* #815 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554943
	/* java_name */
	.ascii	"java/util/HashMap"
	.zero	72
	.zero	1

	/* #816 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554961
	/* java_name */
	.ascii	"java/util/HashSet"
	.zero	72
	.zero	1

	/* #817 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/util/Iterator"
	.zero	71
	.zero	1

	/* #818 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/util/List"
	.zero	75
	.zero	1

	/* #819 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/util/ListIterator"
	.zero	67
	.zero	1

	/* #820 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/util/Queue"
	.zero	74
	.zero	1

	/* #821 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555026
	/* java_name */
	.ascii	"java/util/Random"
	.zero	73
	.zero	1

	/* #822 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/util/RandomAccess"
	.zero	67
	.zero	1

	/* #823 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555027
	/* java_name */
	.ascii	"java/util/TimerTask"
	.zero	70
	.zero	1

	/* #824 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555029
	/* java_name */
	.ascii	"java/util/UUID"
	.zero	75
	.zero	1

	/* #825 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"java/util/concurrent/BlockingQueue"
	.zero	55
	.zero	1

	/* #826 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555032
	/* java_name */
	.ascii	"java/util/concurrent/LinkedBlockingQueue"
	.zero	49
	.zero	1

	/* #827 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555033
	/* java_name */
	.ascii	"java/util/concurrent/TimeUnit"
	.zero	60
	.zero	1

	/* #828 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554560
	/* java_name */
	.ascii	"javax/net/SocketFactory"
	.zero	66
	.zero	1

	/* #829 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"javax/net/ssl/HostnameVerifier"
	.zero	59
	.zero	1

	/* #830 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554562
	/* java_name */
	.ascii	"javax/net/ssl/HttpsURLConnection"
	.zero	57
	.zero	1

	/* #831 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"javax/net/ssl/KeyManager"
	.zero	65
	.zero	1

	/* #832 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554576
	/* java_name */
	.ascii	"javax/net/ssl/KeyManagerFactory"
	.zero	58
	.zero	1

	/* #833 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554577
	/* java_name */
	.ascii	"javax/net/ssl/SSLContext"
	.zero	65
	.zero	1

	/* #834 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"javax/net/ssl/SSLSession"
	.zero	65
	.zero	1

	/* #835 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"javax/net/ssl/SSLSessionContext"
	.zero	58
	.zero	1

	/* #836 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554578
	/* java_name */
	.ascii	"javax/net/ssl/SSLSocketFactory"
	.zero	59
	.zero	1

	/* #837 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"javax/net/ssl/TrustManager"
	.zero	63
	.zero	1

	/* #838 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554580
	/* java_name */
	.ascii	"javax/net/ssl/TrustManagerFactory"
	.zero	56
	.zero	1

	/* #839 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"javax/net/ssl/X509TrustManager"
	.zero	59
	.zero	1

	/* #840 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554556
	/* java_name */
	.ascii	"javax/security/cert/Certificate"
	.zero	58
	.zero	1

	/* #841 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554558
	/* java_name */
	.ascii	"javax/security/cert/X509Certificate"
	.zero	54
	.zero	1

	/* #842 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555185
	/* java_name */
	.ascii	"mono/android/TypeManager"
	.zero	65
	.zero	1

	/* #843 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554889
	/* java_name */
	.ascii	"mono/android/content/DialogInterface_OnClickListenerImplementor"
	.zero	26
	.zero	1

	/* #844 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554936
	/* java_name */
	.ascii	"mono/android/runtime/InputStreamAdapter"
	.zero	50
	.zero	1

	/* #845 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	0
	/* java_name */
	.ascii	"mono/android/runtime/JavaArray"
	.zero	59
	.zero	1

	/* #846 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554958
	/* java_name */
	.ascii	"mono/android/runtime/JavaObject"
	.zero	58
	.zero	1

	/* #847 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554976
	/* java_name */
	.ascii	"mono/android/runtime/OutputStreamAdapter"
	.zero	49
	.zero	1

	/* #848 */
	/* module_index */
	.long	9
	/* type_token_id */
	.long	33554444
	/* java_name */
	.ascii	"mono/android/support/v4/app/FragmentManager_OnBackStackChangedListenerImplementor"
	.zero	8
	.zero	1

	/* #849 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554439
	/* java_name */
	.ascii	"mono/android/support/v4/view/ActionProvider_SubUiVisibilityListenerImplementor"
	.zero	11
	.zero	1

	/* #850 */
	/* module_index */
	.long	16
	/* type_token_id */
	.long	33554443
	/* java_name */
	.ascii	"mono/android/support/v4/view/ActionProvider_VisibilityListenerImplementor"
	.zero	16
	.zero	1

	/* #851 */
	/* module_index */
	.long	13
	/* type_token_id */
	.long	33554441
	/* java_name */
	.ascii	"mono/android/support/v4/widget/DrawerLayout_DrawerListenerImplementor"
	.zero	20
	.zero	1

	/* #852 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554440
	/* java_name */
	.ascii	"mono/android/support/v7/app/ActionBar_OnMenuVisibilityListenerImplementor"
	.zero	16
	.zero	1

	/* #853 */
	/* module_index */
	.long	11
	/* type_token_id */
	.long	33554466
	/* java_name */
	.ascii	"mono/android/support/v7/widget/Toolbar_OnMenuItemClickListenerImplementor"
	.zero	16
	.zero	1

	/* #854 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554657
	/* java_name */
	.ascii	"mono/android/view/View_OnClickListenerImplementor"
	.zero	40
	.zero	1

	/* #855 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554663
	/* java_name */
	.ascii	"mono/android/view/View_OnFocusChangeListenerImplementor"
	.zero	34
	.zero	1

	/* #856 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554667
	/* java_name */
	.ascii	"mono/android/view/View_OnKeyListenerImplementor"
	.zero	42
	.zero	1

	/* #857 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554596
	/* java_name */
	.ascii	"mono/android/widget/AdapterView_OnItemClickListenerImplementor"
	.zero	27
	.zero	1

	/* #858 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554600
	/* java_name */
	.ascii	"mono/android/widget/AdapterView_OnItemLongClickListenerImplementor"
	.zero	23
	.zero	1

	/* #859 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554605
	/* java_name */
	.ascii	"mono/android/widget/AdapterView_OnItemSelectedListenerImplementor"
	.zero	24
	.zero	1

	/* #860 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554711
	/* java_name */
	.ascii	"mono/com/hsm/barcode/DecoderListenerImplementor"
	.zero	42
	.zero	1

	/* #861 */
	/* module_index */
	.long	4
	/* type_token_id */
	.long	33554458
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/analytics/channel/AnalyticsListenerImplementor"
	.zero	14
	.zero	1

	/* #862 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554559
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/channel/Channel_GroupListenerImplementor"
	.zero	20
	.zero	1

	/* #863 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554571
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/channel/Channel_ListenerImplementor"
	.zero	25
	.zero	1

	/* #864 */
	/* module_index */
	.long	18
	/* type_token_id */
	.long	33554447
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/crashes/CrashesListenerImplementor"
	.zero	26
	.zero	1

	/* #865 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554445
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/distribute/DistributeListenerImplementor"
	.zero	20
	.zero	1

	/* #866 */
	/* module_index */
	.long	1
	/* type_token_id */
	.long	33554462
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/distribute/download/ReleaseDownloader_ListenerImplementor"
	.zero	3
	.zero	1

	/* #867 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554464
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/utils/NetworkStateHelper_ListenerImplementor"
	.zero	16
	.zero	1

	/* #868 */
	/* module_index */
	.long	2
	/* type_token_id */
	.long	33554483
	/* java_name */
	.ascii	"mono/com/microsoft/appcenter/utils/context/UserIdContext_ListenerImplementor"
	.zero	13
	.zero	1

	/* #869 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554493
	/* java_name */
	.ascii	"mono/com/rscja/deviceapi/BDNavigation_BDLocationListenerImplementor"
	.zero	22
	.zero	1

	/* #870 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554503
	/* java_name */
	.ascii	"mono/com/rscja/deviceapi/BDNavigation_BDStatusListenerImplementor"
	.zero	24
	.zero	1

	/* #871 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554526
	/* java_name */
	.ascii	"mono/com/rscja/deviceapi/BluetoothReader_OnDataChangeListenerImplementor"
	.zero	17
	.zero	1

	/* #872 */
	/* module_index */
	.long	12
	/* type_token_id */
	.long	33554461
	/* java_name */
	.ascii	"mono/com/zebra/adc/decoder/BarCodeReader_OnZoomChangeListenerImplementor"
	.zero	17
	.zero	1

	/* #873 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33555098
	/* java_name */
	.ascii	"mono/java/lang/RunnableImplementor"
	.zero	55
	.zero	1

	/* #874 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554554
	/* java_name */
	.ascii	"org/json/JSONObject"
	.zero	70
	.zero	1

	/* #875 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554555
	/* java_name */
	.ascii	"org/json/JSONStringer"
	.zero	68
	.zero	1

	/* #876 */
	/* module_index */
	.long	8
	/* type_token_id */
	.long	33554553
	/* java_name */
	.ascii	"xamarin/android/net/OldAndroidSSLSocketFactory"
	.zero	43
	.zero	1

	.size	map_java, 85946
/* Java to managed map: END */


/* java_name_width: START */
	.section	.rodata.java_name_width,"a",@progbits
	.type	java_name_width, @object
	.p2align	2
	.global	java_name_width
java_name_width:
	.size	java_name_width, 4
	.long	90
/* java_name_width: END */
