﻿// <auto-generated />
using System;
using FoodSimpleWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace FoodSimpleWebApi.Migrations
{
    [DbContext(typeof(FoodSimpleDbContext))]
    partial class FoodSimpleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodSimpleWebApi.Models.ProductDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Count")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("RecipeDtoId")
                        .HasColumnType("int");

                    b.Property<int>("Unit")
                        .HasColumnType("int");

                    b.Property<int?>("UserDtoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeDtoId");

                    b.HasIndex("UserDtoId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = 8,
                            Count = "5",
                            Name = "CWTVSPDVWW",
                            Unit = 2
                        },
                        new
                        {
                            Id = 2,
                            Category = 1,
                            Count = "4",
                            Name = "KLJBHVANYH",
                            Unit = 1
                        },
                        new
                        {
                            Id = 3,
                            Category = 6,
                            Count = "6",
                            Name = "SKJVUSKACF",
                            Unit = 2
                        },
                        new
                        {
                            Id = 4,
                            Category = 5,
                            Count = "6",
                            Name = "IGABLJQTCY",
                            Unit = 2
                        },
                        new
                        {
                            Id = 5,
                            Category = 5,
                            Count = "5",
                            Name = "NAISCEREIT",
                            Unit = 0
                        },
                        new
                        {
                            Id = 6,
                            Category = 6,
                            Count = "9",
                            Name = "SLGDQYSUTK",
                            Unit = 2
                        },
                        new
                        {
                            Id = 7,
                            Category = 6,
                            Count = "8",
                            Name = "ZFZXWJKVCF",
                            Unit = 2
                        },
                        new
                        {
                            Id = 8,
                            Category = 5,
                            Count = "3",
                            Name = "QYGJQNJGDU",
                            Unit = 1
                        },
                        new
                        {
                            Id = 9,
                            Category = 8,
                            Count = "5",
                            Name = "SOVRZRQWVO",
                            Unit = 1
                        },
                        new
                        {
                            Id = 10,
                            Category = 3,
                            Count = "3",
                            Name = "OYFFRWSFHX",
                            Unit = 0
                        });
                });

            modelBuilder.Entity("FoodSimpleWebApi.Models.RecipeDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Difficult")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UserDtoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserDtoId");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "OKDAPBBBRJXJEXWOHQTOMHKDEHKKOXBLTPUBUQKSTCVEYTXBEXMCDATLCMACCPUXQYQIGUALQBWPGZXEUSRPRPUSFHYALKBLOLKPWIDFEYXUTVTMUUJTTYJGCDLZLKHBZFVLNIVLEGFUFOVFWIIIBUVCTJZDFBZCQWIMXVRZTYGPLXSFEVNUGQWVDGSKIROQPTLEGRUVMRIVAASSYANVCVKYUEMPNDGMMQZNYZSJKQOYCFPMLSHJTPFRQQPSTJQINWRBNRGYSRRQWTKFOFRDARWHSJEORCDULCZTMASZFVYKQYJMXFWTKUPWHHHDLULXKOOWCKMOKMEPINHNXIXUKQXSAOAHIQWMKYEXTFGOGPYFMAVMXOUZWDIIUVCFXINLHPZCIHXBLGRWKZFWPBWSJWJDKHWNDCSEVACHTTLCBYFKRGZCHYHPTSMSPRZWODZGSPZSKVLYCZYFEPSPJIRQRVMTFBKDYUQNKXITHCAVLEKVVOFTVQDW",
                            Difficult = 1,
                            Name = "DPMKVUYLVA"
                        },
                        new
                        {
                            Id = 2,
                            Description = "SWYOLARKISRVLAMNOLIVGQWYCHOEIILJXPMZOGVQULZMMAJWBAPQTZBLMOKTAINILWOEIFNYFHOCDSTSLGMLMSOHBESXFGKJASCYBZINUNTMNHYSRVLPJUOEHDDYPWFSCTJTKXXJXRREICUVFPDFVSPUXLKAXUHRNIIYXENRHRCXHZXABNORXIBMBDBQZDATKSXARHYYNKLRKHXNXSCZXGCNZEZVUEUCIZPVMHYVZQDYQTFOHELCDFIOZQIJBWSUULNEUDAEHTKMXKLLHRVTBSVGAUNUWBAPNLTCODJAEYKHRFYYKAJQRKVGXYBCSBENPDISIIZEINSLWYUDQKQEKTWNTGEQMADDHJXNKBXHCKPNNKKOMHNMGEFKLDUPGVKPELGUPMAKWTWLGBQCXLQVSWWQQAWCXWXVISAITIFIBDYYPKKSNSIEOJEIMQWAKNRAZBKCRVTYUDPHZQRWKTVXURGQAXTYXAHLWPXUTGJCEZMSIRUZQVCN",
                            Difficult = 3,
                            Name = "MVQOBEXPVK"
                        },
                        new
                        {
                            Id = 3,
                            Description = "HVEGAIDHSFJCPRIKLHEAYPLBFAFEBWUNBRSSICMJGKAIUUJADYREDNNMAKWAHRZGTMYZFIAXBRXPXXRHKUVNPYMIONCDFWFTHXRUFSOLOSZPDTFQPWHSDNOZJTMAUURUQCCVBTESBEEJRSPLUAKPUZNVJQEGGSTDFURIRUTGHNDDZCGCDNOJXPVSZXPSMQFXEETPQDCCTKSZZVIUFLOSRCUNXKXPNKRNPMAVUUCYMEEIVJSXUYFBWUZXQJIHDMEQNAMEUWDHJRMVHCNJQDSCWNPWVCQAYVEMBLYFJDVSIJKFZUVPBZKBCNYICJHTNEATUFERTQHSZTEBATNHQNYXHYQRSCVLENYONEJJNHOJEEUVQIFZANNOBCFHQIQWRPEHUYMNAAHPJQVFXGIQNXSNSPMATXPJZHFKKSQQXORTDTJGSDNOYMOYMFSOJZIMBPHOOSFIURZPTJHCCXCTATJECLWAZVOEXLSNQGVEADIAQKWYQWRNRANY",
                            Difficult = 1,
                            Name = "PJXJCZOLPY"
                        },
                        new
                        {
                            Id = 4,
                            Description = "WWKLLIDGPQVWRHNXSZPFGTCNZTECAJNYEMHFMLYAJQEFLPNWMEGKDKWYDFHZXOHWUFILRHURSIGWJFJXVODYICWMSZIGNTJHFJRCOEJKLQYSDGOPWTCRMIUTCCSPZUYOZRWDBFBPMMDXZTSEPCKYEFMJDOTJJMREHJLIJOBWEHSNZLCGVXSGNRICUQPBPKBASWETICABUVICIOMGWQWYPUSUOYWJNZITSYMFJKYPYSXTEKMVHHHTKIMJLHFLEHUPFDUVMYJNTVFESAGHUWKRIPMOLYWFMSRTOVXPOZOTPVTGVEREWXEPQBPDFZQOEOYCAYTOXLOPKKQCLIPXNWVSRUYJOWPGGECDCFVENDSWZLMNSZCRHQWDBKUNRGFTERLEXSRYHSVGQESVNKSBVDZQNETXEODIDOIUOOELRAEHJFDAZUOHWWKDBRBHZCFSVRZODLLGYAIALREAUEDSLALBMPEPBIKOQBQGPGUCLKUVBWXUCMWHAKRV",
                            Difficult = 3,
                            Name = "WKSBLTNCDJ"
                        },
                        new
                        {
                            Id = 5,
                            Description = "BNIMDHYPMUUBWNGOPOGMSBWKSEZHCKVWWJZWNGSALTPGVGJIFMKAQAGFVSWLDMAPQARZYAUVIHCKOAWZSISDTRYDRVOFKAUGCVXSRDUAUPZMXJQYFFXAHYJPBZWEUIBXUEXGSSDYZUZKVVVATRXMEZRAUNZAGYHIPKMJKKHRHPWFPIIPTCIPOYKTUTGCPCVFVKHZEXGIDOVJHCQHXEPBNSPISIQZJGYEMGALLNALNTNIJENZIKCOBMKPRVCZUERUJLNPAGPQGYVITNFWQNEVMQRGAEYLMUTOJIZMJOXBDCURUFMFODOSIBVBKJKTACHHSONHCPOOSBHSPKEDFTMIUBGKASMTZXMNFHSVQZSJIVARTHYEGZEBXFXOUQFATFVXEHPNVJLKTPBPIFJOUIEAOXZVGKKPMAHBSWQAUHQITKQWORRIGBAFBKGGLPWTRJMEBNUJCMCWDKFNSYATEAMKZSZLLHZFWNLTHRJNRYKUMNXZYMBMJBTF",
                            Difficult = 1,
                            Name = "RSXVZJCSHM"
                        },
                        new
                        {
                            Id = 6,
                            Description = "PTONVLNIIQWZOLHAXTQTWBJAWGYJLCXZRJOMEWDNXBAIUHUPRDTSPVTXTCFXVBNTAZBTSKFPKYEGNCQRTUWHPJZBBRYNEVWXTMGVTUDDCWCDSEEXXMRQPGGTZFVSASTJJMTEDUVIDXIYRLVWOCYZTXCWYYPDEAFFGKMPHXKQCBYHNQECEIPZTKXGYKETDTUKGTEVLDCRSIJJBDTLLTKDEJJJBNOQMHHKZJXNYABCMLNAJKHCCLPMNWMTNMBTTMYMMBRHMOEZNGFVHQLBDADWULRTHYQSDXBSSSDLDANGPCEYXLUHWKRVOXXEYYWPYFMDFIWUSTWIUAFGQEAJCZSTLUEWREXGFMPAXJVXEIDJCSIUYQOLYVRQIRXYCKMYZGTNBYRHDUOATKZSBBKTMMJVQHYDXPBEEOJORLZXSZEXOCDMATGDNIUNSLLEPJBLVHRVSOYYWDPCKHXXDCCRQWLGYGAEKSKGRAVTXXBEUEBUMWLRAGEUSNEZ",
                            Difficult = 3,
                            Name = "QYSGSDMBRZ"
                        },
                        new
                        {
                            Id = 7,
                            Description = "IDQCJNCDRCBXZXVNGLWLYSKLUXXZDTLBBXLHRTDSNGMYGIKUNWFESRAHTATJZLCZYFYEIFSXAKUXUYIPTWLFAPLKDSIRYLWZCEHLLLFDWCIKLNJAZFHMHIFXGWYOJSSQLFJIYPGXNTRYKLCRQJCWVJWPZASNEDCPIYGZARVLPNSUUSJIYERWRCCSZJEHGULCMZRQIUGBPXBVQLHQBLOYGUZMPQFFBXYVLIOTMWCYRVZKNITNNAQLTUWSTSMLEOBXGCEYQXHVTEAFFYVQIFHMRQEBLIPBUTTNYPPGRMLLSXNNLGIVYRRURXFCWDKVZKPXWGGRQVUMQUHGWPSECYODNALKSDWZLGNTQVQXJJYMYFKPEATWQAJZGVAOSRAYTGXYSQXQCRJCKDPTEELFCUDXCIEAZDFZBBRVUNQSAIORQYPWRKWDXGIIPRKJQXQUNKPAKEMYBVWCPHGLOOREPYXZGZKASPWEKQOXFSCFLMLXRNGYUTPAHMWT",
                            Difficult = 3,
                            Name = "SHKURUABGR"
                        },
                        new
                        {
                            Id = 8,
                            Description = "NDGQMQBEZVYUGTYNRQOAWTFDGZWGVQUPQPJUUCYGLSIJFPFMFSIWAGTXEXZULXRTPGKDVRKFEFFTOICELVNPVEARUAGLSHREQLUERAXPKKPFYLJNOYDRUHFZQECWFPPDPTPXYJFRZGXEVQLXAJJTDZDVVWNSHDDEYLREPTJUFPOVRZOFCJRMQKGIFAXECMPRVHSDESBEMELSSPUVNYQTXQFEEEFUNWTVZMBPYJWXSFQMSSYWXCRKIQELJOOITTUKJEJSWXIELLAPAJCGGNSXJTHPGURMGCQFSKMQWZZNWRSMBNIOIGTDECQALWZGJLSYEDBYEOEXQJUVNDRLTLXOCJNSPBOTASRUJZPBRSMSACSFAPMSSRVSTTWUAYGBWTHIKFXAJSZQVHROWQWULTYWKGNNCHUFWPMHUJIPLGWYCNTEDIDEOELMSNEFIVRKKMVHFHWWKOJVODOZITBPIYJIHRKAIOKNZXNYPLNFTKKAXPCIURJHTWAV",
                            Difficult = 1,
                            Name = "PKOUCXBGXD"
                        },
                        new
                        {
                            Id = 9,
                            Description = "HHEKRPGLIPGCMLJNRXCLKZSXYTGNIZWSUTLXPTBZZKIQLWQJCUHZNUMDGHOCUUQBPPYOIOKSRIAVZCGTPFFHQFAILNVRGSQILMMIMFEODHIFXPRRDTVKFJZJWXWOYLOKNBZRJOZRKGOIKHYMRISYYAOCCEBJEVCCLTGRTYVNRPCOPKWDGJFTPJYVICNZEWWNNHEEMFGRTLVQLSNWTXFOCZJRPZOCYOYMFZFHOUNTFEBDDAADCHDKZFFDGFHGKATXFIIJEQXUCZITPLSNDUHRJDEGXESWBRBOFJNXNVFBIGMWYSCFYUAWLBTHBYOXDQXFIQZFAKPDABNRELYISUOVUGHCCGTOTQBVMILTLQPJWMGIYJHRDJGKVAXXJMPAKQLQBFPSDNYZXZCYERRXEJKSXKBMZSMOUGTCPCTNZCAYHLTYLTWNRBALFXMKJJNEYLDTNGGYSWDCFFBRRLIIPDSBPXQYUXTGCDWZNHXDKXXVQEQGAMTUIQKC",
                            Difficult = 1,
                            Name = "QULJMLPFPW"
                        },
                        new
                        {
                            Id = 10,
                            Description = "IJXDQRXZXDSOWVXSOYYHIYRJIUQSDGUAUWTFLCPZFDJRNWRSESPPDCUJFMENBCFBBIEQRSGNOAJTVEBHIUWJVNADRVVJJNUBEVLYBNEOPQDNLHMSQQKSRZTYTUTEKLBQPDFCQRCZGFNXGTUOATUWVGKLKPLMFTPYGMCXZNJPNVDBJFWMNFQDKDMHHOLTQTXKLXYCRMMIUBNFVUZHNTCDAPMRBTDYYYJHSNHFVTNKHOSNYPJPOIYBLPZFXQLFIFSSLFMEHETZPUBYUNDOZRHFUSXZLGRHWBOHBFJOXHDHQUCYKTUMPDUFVKTYNVIDICVEVXJMKGRJXKLYNFJFQJZQQBNISAEMAUKLAYQKIWHALRNDWCVBLLNMHRMNCAKKKWVACEGTFXZIAHKFWVZGBZOAHNUQYLQHDRXEABOVPFFVZLBBBHDKWKURMBBASANJMONAXRJSNRBBCRXCMILYOUBYJGCJFHSUZSNNYNNLNNMZUWLBRVONNRQY",
                            Difficult = 2,
                            Name = "NKXLCBMWYK"
                        });
                });

            modelBuilder.Entity("FoodSimpleWebApi.Models.UserDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ASYDXXY@gmail.com"
                        },
                        new
                        {
                            Id = 2,
                            Email = "KPODLQG@gmail.com"
                        },
                        new
                        {
                            Id = 3,
                            Email = "BCZANZJ@gmail.com"
                        },
                        new
                        {
                            Id = 4,
                            Email = "SOJNWQW@gmail.com"
                        },
                        new
                        {
                            Id = 5,
                            Email = "ZFNGCOD@gmail.com"
                        });
                });

            modelBuilder.Entity("FoodSimpleWebApi.Models.ProductDto", b =>
                {
                    b.HasOne("FoodSimpleWebApi.Models.RecipeDto", null)
                        .WithMany("Products")
                        .HasForeignKey("RecipeDtoId");

                    b.HasOne("FoodSimpleWebApi.Models.UserDto", null)
                        .WithMany("Products")
                        .HasForeignKey("UserDtoId");
                });

            modelBuilder.Entity("FoodSimpleWebApi.Models.RecipeDto", b =>
                {
                    b.HasOne("FoodSimpleWebApi.Models.UserDto", null)
                        .WithMany("Recipes")
                        .HasForeignKey("UserDtoId");
                });

            modelBuilder.Entity("FoodSimpleWebApi.Models.RecipeDto", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FoodSimpleWebApi.Models.UserDto", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
