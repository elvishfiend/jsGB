using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csGB
{
    public static class Z80
    {
		public static class _r
		{
			public static int a = 0;
			public static int b = 0;
			public static int c = 0;
			public static int d = 0;
			public static int e = 0;
			public static int h = 0;
			public static int l = 0;
			public static int f = 0;
			public static int sp = 0;
			public static int pc = 0;

			public static int i = 0;
			public static int r = 0;
			public static int m = 0;
            public static int ime = 0;
		}

		public static class _rsv
		{
			public static int a = 0;
			public static int b = 0;
			public static int c = 0;
			public static int d = 0;
			public static int e = 0;
			public static int h = 0;
			public static int l = 0;
			public static int f = 0;
		}

		public static class _clock
		{
			public static int m = 0;
            public static int t = 0;
		}

		public static bool _halt = false;
		public static bool _stop = false;
		
		public static void reset()
		{
			Z80._r.a=0; Z80._r.b=0; Z80._r.c=0; Z80._r.d=0; Z80._r.e=0; Z80._r.h=0; Z80._r.l=0; Z80._r.f=0;
			Z80._r.sp=0; Z80._r.pc=0; Z80._r.i=0; Z80._r.r=0;
			Z80._r.m=0;
			Z80._halt = false; Z80._stop = false;
			Z80._clock.m=0;
			Z80._r.ime=1;
			LOG.@out("Z80", "Reset.");
		}

		public static void exec()
		{
			Z80._r.r = (Z80._r.r+1) & 127;
			Z80._map[MMU.rb(Z80._r.pc++)]();
			Z80._r.pc &= 65535;
			Z80._clock.m += Z80._r.m;
		}

        #region FUNCTIONS
        public static class _ops
        {
            /*--- Load/store ---*/
            public static void LDrr_bb() { Z80._r.b = Z80._r.b; Z80._r.m = 1; }
            public static void LDrr_bc() { Z80._r.b = Z80._r.c; Z80._r.m = 1; }
            public static void LDrr_bd() { Z80._r.b = Z80._r.d; Z80._r.m = 1; }
            public static void LDrr_be() { Z80._r.b = Z80._r.e; Z80._r.m = 1; }
            public static void LDrr_bh() { Z80._r.b = Z80._r.h; Z80._r.m = 1; }
            public static void LDrr_bl() { Z80._r.b = Z80._r.l; Z80._r.m = 1; }
            public static void LDrr_ba() { Z80._r.b = Z80._r.a; Z80._r.m = 1; }
            public static void LDrr_cb() { Z80._r.c = Z80._r.b; Z80._r.m = 1; }
            public static void LDrr_cc() { Z80._r.c = Z80._r.c; Z80._r.m = 1; }
            public static void LDrr_cd() { Z80._r.c = Z80._r.d; Z80._r.m = 1; }
            public static void LDrr_ce() { Z80._r.c = Z80._r.e; Z80._r.m = 1; }
            public static void LDrr_ch() { Z80._r.c = Z80._r.h; Z80._r.m = 1; }
            public static void LDrr_cl() { Z80._r.c = Z80._r.l; Z80._r.m = 1; }
            public static void LDrr_ca() { Z80._r.c = Z80._r.a; Z80._r.m = 1; }
            public static void LDrr_db() { Z80._r.d = Z80._r.b; Z80._r.m = 1; }
            public static void LDrr_dc() { Z80._r.d = Z80._r.c; Z80._r.m = 1; }
            public static void LDrr_dd() { Z80._r.d = Z80._r.d; Z80._r.m = 1; }
            public static void LDrr_de() { Z80._r.d = Z80._r.e; Z80._r.m = 1; }
            public static void LDrr_dh() { Z80._r.d = Z80._r.h; Z80._r.m = 1; }
            public static void LDrr_dl() { Z80._r.d = Z80._r.l; Z80._r.m = 1; }
            public static void LDrr_da() { Z80._r.d = Z80._r.a; Z80._r.m = 1; }
            public static void LDrr_eb() { Z80._r.e = Z80._r.b; Z80._r.m = 1; }
            public static void LDrr_ec() { Z80._r.e = Z80._r.c; Z80._r.m = 1; }
            public static void LDrr_ed() { Z80._r.e = Z80._r.d; Z80._r.m = 1; }
            public static void LDrr_ee() { Z80._r.e = Z80._r.e; Z80._r.m = 1; }
            public static void LDrr_eh() { Z80._r.e = Z80._r.h; Z80._r.m = 1; }
            public static void LDrr_el() { Z80._r.e = Z80._r.l; Z80._r.m = 1; }
            public static void LDrr_ea() { Z80._r.e = Z80._r.a; Z80._r.m = 1; }
            public static void LDrr_hb() { Z80._r.h = Z80._r.b; Z80._r.m = 1; }
            public static void LDrr_hc() { Z80._r.h = Z80._r.c; Z80._r.m = 1; }
            public static void LDrr_hd() { Z80._r.h = Z80._r.d; Z80._r.m = 1; }
            public static void LDrr_he() { Z80._r.h = Z80._r.e; Z80._r.m = 1; }
            public static void LDrr_hh() { Z80._r.h = Z80._r.h; Z80._r.m = 1; }
            public static void LDrr_hl() { Z80._r.h = Z80._r.l; Z80._r.m = 1; }
            public static void LDrr_ha() { Z80._r.h = Z80._r.a; Z80._r.m = 1; }
            public static void LDrr_lb() { Z80._r.l = Z80._r.b; Z80._r.m = 1; }
            public static void LDrr_lc() { Z80._r.l = Z80._r.c; Z80._r.m = 1; }
            public static void LDrr_ld() { Z80._r.l = Z80._r.d; Z80._r.m = 1; }
            public static void LDrr_le() { Z80._r.l = Z80._r.e; Z80._r.m = 1; }
            public static void LDrr_lh() { Z80._r.l = Z80._r.h; Z80._r.m = 1; }
            public static void LDrr_ll() { Z80._r.l = Z80._r.l; Z80._r.m = 1; }
            public static void LDrr_la() { Z80._r.l = Z80._r.a; Z80._r.m = 1; }
            public static void LDrr_ab() { Z80._r.a = Z80._r.b; Z80._r.m = 1; }
            public static void LDrr_ac() { Z80._r.a = Z80._r.c; Z80._r.m = 1; }
            public static void LDrr_ad() { Z80._r.a = Z80._r.d; Z80._r.m = 1; }
            public static void LDrr_ae() { Z80._r.a = Z80._r.e; Z80._r.m = 1; }
            public static void LDrr_ah() { Z80._r.a = Z80._r.h; Z80._r.m = 1; }
            public static void LDrr_al() { Z80._r.a = Z80._r.l; Z80._r.m = 1; }
            public static void LDrr_aa() { Z80._r.a = Z80._r.a; Z80._r.m = 1; }

            public static void LDrHLm_b() { Z80._r.b = MMU.rb((Z80._r.h << 8) + Z80._r.l); Z80._r.m = 2; }
            public static void LDrHLm_c() { Z80._r.c = MMU.rb((Z80._r.h << 8) + Z80._r.l); Z80._r.m = 2; }
            public static void LDrHLm_d() { Z80._r.d = MMU.rb((Z80._r.h << 8) + Z80._r.l); Z80._r.m = 2; }
            public static void LDrHLm_e() { Z80._r.e = MMU.rb((Z80._r.h << 8) + Z80._r.l); Z80._r.m = 2; }
            public static void LDrHLm_h() { Z80._r.h = MMU.rb((Z80._r.h << 8) + Z80._r.l); Z80._r.m = 2; }
            public static void LDrHLm_l() { Z80._r.l = MMU.rb((Z80._r.h << 8) + Z80._r.l); Z80._r.m = 2; }
            public static void LDrHLm_a() { Z80._r.a = MMU.rb((Z80._r.h << 8) + Z80._r.l); Z80._r.m = 2; }

            public static void LDHLmr_b() { MMU.wb((Z80._r.h << 8) + Z80._r.l, Z80._r.b); Z80._r.m = 2; }
            public static void LDHLmr_c() { MMU.wb((Z80._r.h << 8) + Z80._r.l, Z80._r.c); Z80._r.m = 2; }
            public static void LDHLmr_d() { MMU.wb((Z80._r.h << 8) + Z80._r.l, Z80._r.d); Z80._r.m = 2; }
            public static void LDHLmr_e() { MMU.wb((Z80._r.h << 8) + Z80._r.l, Z80._r.e); Z80._r.m = 2; }
            public static void LDHLmr_h() { MMU.wb((Z80._r.h << 8) + Z80._r.l, Z80._r.h); Z80._r.m = 2; }
            public static void LDHLmr_l() { MMU.wb((Z80._r.h << 8) + Z80._r.l, Z80._r.l); Z80._r.m = 2; }
            public static void LDHLmr_a() { MMU.wb((Z80._r.h << 8) + Z80._r.l, Z80._r.a); Z80._r.m = 2; }

            public static void LDrn_b() { Z80._r.b = MMU.rb(Z80._r.pc); Z80._r.pc++; Z80._r.m = 2; }
            public static void LDrn_c() { Z80._r.c = MMU.rb(Z80._r.pc); Z80._r.pc++; Z80._r.m = 2; }
            public static void LDrn_d() { Z80._r.d = MMU.rb(Z80._r.pc); Z80._r.pc++; Z80._r.m = 2; }
            public static void LDrn_e() { Z80._r.e = MMU.rb(Z80._r.pc); Z80._r.pc++; Z80._r.m = 2; }
            public static void LDrn_h() { Z80._r.h = MMU.rb(Z80._r.pc); Z80._r.pc++; Z80._r.m = 2; }
            public static void LDrn_l() { Z80._r.l = MMU.rb(Z80._r.pc); Z80._r.pc++; Z80._r.m = 2; }
            public static void LDrn_a() { Z80._r.a = MMU.rb(Z80._r.pc); Z80._r.pc++; Z80._r.m = 2; }

            public static void LDHLmn() { MMU.wb((Z80._r.h << 8) + Z80._r.l, MMU.rb(Z80._r.pc)); Z80._r.pc++; Z80._r.m = 3; }

            public static void LDBCmA() { MMU.wb((Z80._r.b << 8) + Z80._r.c, Z80._r.a); Z80._r.m = 2; }
            public static void LDDEmA() { MMU.wb((Z80._r.d << 8) + Z80._r.e, Z80._r.a); Z80._r.m = 2; }

            public static void LDmmA() { MMU.wb(MMU.rw(Z80._r.pc), Z80._r.a); Z80._r.pc += 2; Z80._r.m = 4; }

            public static void LDABCm() { Z80._r.a = MMU.rb((Z80._r.b << 8) + Z80._r.c); Z80._r.m = 2; }
            public static void LDADEm() { Z80._r.a = MMU.rb((Z80._r.d << 8) + Z80._r.e); Z80._r.m = 2; }

            public static void LDAmm() { Z80._r.a = MMU.rb(MMU.rw(Z80._r.pc)); Z80._r.pc += 2; Z80._r.m = 4; }

            public static void LDBCnn() { Z80._r.c = MMU.rb(Z80._r.pc); Z80._r.b = MMU.rb(Z80._r.pc + 1); Z80._r.pc += 2; Z80._r.m = 3; }
            public static void LDDEnn() { Z80._r.e = MMU.rb(Z80._r.pc); Z80._r.d = MMU.rb(Z80._r.pc + 1); Z80._r.pc += 2; Z80._r.m = 3; }
            public static void LDHLnn() { Z80._r.l = MMU.rb(Z80._r.pc); Z80._r.h = MMU.rb(Z80._r.pc + 1); Z80._r.pc += 2; Z80._r.m = 3; }
            public static void LDSPnn() { Z80._r.sp = MMU.rw(Z80._r.pc); Z80._r.pc += 2; Z80._r.m = 3; }

            public static void LDHLmm() { var i = MMU.rw(Z80._r.pc); Z80._r.pc += 2; Z80._r.l = MMU.rb(i); Z80._r.h = MMU.rb(i + 1); Z80._r.m = 5; }
            //public static void LDmmHL() { var i = MMU.rw(Z80._r.pc); Z80._r.pc += 2; MMU.ww(i, (Z80._r.h << 8) + Z80._r.l); Z80._r.m = 5; }
            public static void LDmmSP() { var i = MMU.rw(Z80._r.pc); Z80._r.pc += 2; MMU.ww(i, (Z80._r.sp)); Z80._r.m = 5; }

            public static void LDHLIA() { MMU.wb((Z80._r.h << 8) + Z80._r.l, Z80._r.a); Z80._r.l = (Z80._r.l + 1) & 255; if (Z80._r.l == 0) Z80._r.h = (Z80._r.h + 1) & 255; Z80._r.m = 2; }
            public static void LDAHLI() { Z80._r.a = MMU.rb((Z80._r.h << 8) + Z80._r.l); Z80._r.l = (Z80._r.l + 1) & 255; if (Z80._r.l == 0) Z80._r.h = (Z80._r.h + 1) & 255; Z80._r.m = 2; }

            public static void LDHLDA() { MMU.wb((Z80._r.h << 8) + Z80._r.l, Z80._r.a); Z80._r.l = (Z80._r.l - 1) & 255; if (Z80._r.l == 255) Z80._r.h = (Z80._r.h - 1) & 255; Z80._r.m = 2; }
            public static void LDAHLD() { Z80._r.a = MMU.rb((Z80._r.h << 8) + Z80._r.l); Z80._r.l = (Z80._r.l - 1) & 255; if (Z80._r.l == 255) Z80._r.h = (Z80._r.h - 1) & 255; Z80._r.m = 2; }

            public static void LDAIOn() { Z80._r.a = MMU.rb(0xFF00 + MMU.rb(Z80._r.pc)); Z80._r.pc++; Z80._r.m = 3; }
            public static void LDIOnA() { MMU.wb(0xFF00 + MMU.rb(Z80._r.pc), Z80._r.a); Z80._r.pc++; Z80._r.m = 3; }
            public static void LDAIOC() { Z80._r.a = MMU.rb(0xFF00 + Z80._r.c); Z80._r.m = 2; }
            public static void LDIOCA() { MMU.wb(0xFF00 + Z80._r.c, Z80._r.a); Z80._r.m = 2; }

            public static void LDHLSPn() { var i = MMU.rb(Z80._r.pc); if (i > 127) i = -((~i + 1) & 255); Z80._r.pc++; i += Z80._r.sp; Z80._r.h = (i >> 8) & 255; Z80._r.l = i & 255; Z80._r.m = 3; }

            public static void SWAPr_b() { var tr = Z80._r.b; Z80._r.b = ((tr & 0xF) << 4) | ((tr & 0xF0) >> 4); Z80._r.f = Z80._r.b != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void SWAPr_c() { var tr = Z80._r.c; Z80._r.c = ((tr & 0xF) << 4) | ((tr & 0xF0) >> 4); Z80._r.f = Z80._r.c != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void SWAPr_d() { var tr = Z80._r.d; Z80._r.d = ((tr & 0xF) << 4) | ((tr & 0xF0) >> 4); Z80._r.f = Z80._r.d != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void SWAPr_e() { var tr = Z80._r.e; Z80._r.e = ((tr & 0xF) << 4) | ((tr & 0xF0) >> 4); Z80._r.f = Z80._r.e != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void SWAPr_h() { var tr = Z80._r.h; Z80._r.h = ((tr & 0xF) << 4) | ((tr & 0xF0) >> 4); Z80._r.f = Z80._r.h != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void SWAPr_l() { var tr = Z80._r.l; Z80._r.l = ((tr & 0xF) << 4) | ((tr & 0xF0) >> 4); Z80._r.f = Z80._r.l != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void SWAPr_a() { var tr = Z80._r.a; Z80._r.a = ((tr & 0xF) << 4) | ((tr & 0xF0) >> 4); Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }

            /*--- Data processing ---*/
            public static void ADDr_b() { var a = Z80._r.a; Z80._r.a += Z80._r.b; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.b ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void ADDr_c() { var a = Z80._r.a; Z80._r.a += Z80._r.c; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.c ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void ADDr_d() { var a = Z80._r.a; Z80._r.a += Z80._r.d; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.d ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void ADDr_e() { var a = Z80._r.a; Z80._r.a += Z80._r.e; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.e ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void ADDr_h() { var a = Z80._r.a; Z80._r.a += Z80._r.h; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.h ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void ADDr_l() { var a = Z80._r.a; Z80._r.a += Z80._r.l; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.l ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void ADDr_a() { var a = Z80._r.a; Z80._r.a += Z80._r.a; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.a ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void ADDHL() { var a = Z80._r.a; var m = MMU.rb((Z80._r.h << 8) + Z80._r.l); Z80._r.a += m; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ a ^ m) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 2; }
            public static void ADDn() { var a = Z80._r.a; var m = MMU.rb(Z80._r.pc); Z80._r.a += m; Z80._r.pc++; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ a ^ m) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 2; }
            public static void ADDHLBC() { var hl = (Z80._r.h << 8) + Z80._r.l; hl += (Z80._r.b << 8) + Z80._r.c; if (hl > 65535) Z80._r.f |= 0x10; else Z80._r.f &= 0xEF; Z80._r.h = (hl >> 8) & 255; Z80._r.l = hl & 255; Z80._r.m = 3; }
            public static void ADDHLDE() { var hl = (Z80._r.h << 8) + Z80._r.l; hl += (Z80._r.d << 8) + Z80._r.e; if (hl > 65535) Z80._r.f |= 0x10; else Z80._r.f &= 0xEF; Z80._r.h = (hl >> 8) & 255; Z80._r.l = hl & 255; Z80._r.m = 3; }
            public static void ADDHLHL() { var hl = (Z80._r.h << 8) + Z80._r.l; hl += (Z80._r.h << 8) + Z80._r.l; if (hl > 65535) Z80._r.f |= 0x10; else Z80._r.f &= 0xEF; Z80._r.h = (hl >> 8) & 255; Z80._r.l = hl & 255; Z80._r.m = 3; }
            public static void ADDHLSP() { var hl = (Z80._r.h << 8) + Z80._r.l; hl += Z80._r.sp; if (hl > 65535) Z80._r.f |= 0x10; else Z80._r.f &= 0xEF; Z80._r.h = (hl >> 8) & 255; Z80._r.l = hl & 255; Z80._r.m = 3; }
            public static void ADDSPn() { var i = MMU.rb(Z80._r.pc); if (i > 127) i = -((~i + 1) & 255); Z80._r.pc++; Z80._r.sp += i; Z80._r.m = 4; }

            public static void ADCr_b() { var a = Z80._r.a; Z80._r.a += Z80._r.b; Z80._r.a += (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.b ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void ADCr_c() { var a = Z80._r.a; Z80._r.a += Z80._r.c; Z80._r.a += (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.c ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void ADCr_d() { var a = Z80._r.a; Z80._r.a += Z80._r.d; Z80._r.a += (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.d ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void ADCr_e() { var a = Z80._r.a; Z80._r.a += Z80._r.e; Z80._r.a += (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.e ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void ADCr_h() { var a = Z80._r.a; Z80._r.a += Z80._r.h; Z80._r.a += (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.h ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void ADCr_l() { var a = Z80._r.a; Z80._r.a += Z80._r.l; Z80._r.a += (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.l ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void ADCr_a() { var a = Z80._r.a; Z80._r.a += Z80._r.a; Z80._r.a += (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.a ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void ADCHL() { var a = Z80._r.a; var m = MMU.rb((Z80._r.h << 8) + Z80._r.l); Z80._r.a += m; Z80._r.a += (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ m ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 2; }
            public static void ADCn() { var a = Z80._r.a; var m = MMU.rb(Z80._r.pc); Z80._r.a += m; Z80._r.pc++; Z80._r.a += (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a > 255) ? 0x10 : 0; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ m ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 2; }

            public static void SUBr_b() { var a = Z80._r.a; Z80._r.a -= Z80._r.b; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.b ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void SUBr_c() { var a = Z80._r.a; Z80._r.a -= Z80._r.c; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.c ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void SUBr_d() { var a = Z80._r.a; Z80._r.a -= Z80._r.d; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.d ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void SUBr_e() { var a = Z80._r.a; Z80._r.a -= Z80._r.e; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.e ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void SUBr_h() { var a = Z80._r.a; Z80._r.a -= Z80._r.h; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.h ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void SUBr_l() { var a = Z80._r.a; Z80._r.a -= Z80._r.l; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.l ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void SUBr_a() { var a = Z80._r.a; Z80._r.a -= Z80._r.a; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.a ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void SUBHL() { var a = Z80._r.a; var m = MMU.rb((Z80._r.h << 8) + Z80._r.l); Z80._r.a -= m; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ m ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 2; }
            public static void SUBn() { var a = Z80._r.a; var m = MMU.rb(Z80._r.pc); Z80._r.a -= m; Z80._r.pc++; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ m ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 2; }

            public static void SBCr_b() { var a = Z80._r.a; Z80._r.a -= Z80._r.b; Z80._r.a -= (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.b ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void SBCr_c() { var a = Z80._r.a; Z80._r.a -= Z80._r.c; Z80._r.a -= (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.c ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void SBCr_d() { var a = Z80._r.a; Z80._r.a -= Z80._r.d; Z80._r.a -= (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.d ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void SBCr_e() { var a = Z80._r.a; Z80._r.a -= Z80._r.e; Z80._r.a -= (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.e ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void SBCr_h() { var a = Z80._r.a; Z80._r.a -= Z80._r.h; Z80._r.a -= (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.h ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void SBCr_l() { var a = Z80._r.a; Z80._r.a -= Z80._r.l; Z80._r.a -= (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.l ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void SBCr_a() { var a = Z80._r.a; Z80._r.a -= Z80._r.a; Z80._r.a -= (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.a ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void SBCHL() { var a = Z80._r.a; var m = MMU.rb((Z80._r.h << 8) + Z80._r.l); Z80._r.a -= m; Z80._r.a -= (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ m ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 2; }
            public static void SBCn() { var a = Z80._r.a; var m = MMU.rb(Z80._r.pc); Z80._r.a -= m; Z80._r.pc++; Z80._r.a -= (Z80._r.f & 0x10) != 0 ? 1 : 0; Z80._r.f = (Z80._r.a < 0) ? 0x50 : 0x40; Z80._r.a &= 255; if (Z80._r.a == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ m ^ a) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 2; }

            public static void CPr_b() { var i = Z80._r.a; i -= Z80._r.b; Z80._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.b ^ i) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void CPr_c() { var i = Z80._r.a; i -= Z80._r.c; Z80._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.c ^ i) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void CPr_d() { var i = Z80._r.a; i -= Z80._r.d; Z80._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.d ^ i) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void CPr_e() { var i = Z80._r.a; i -= Z80._r.e; Z80._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.e ^ i) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void CPr_h() { var i = Z80._r.a; i -= Z80._r.h; Z80._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.h ^ i) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void CPr_l() { var i = Z80._r.a; i -= Z80._r.l; Z80._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.l ^ i) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void CPr_a() { var i = Z80._r.a; i -= Z80._r.a; Z80._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ Z80._r.a ^ i) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 1; }
            public static void CPHL() { var i = Z80._r.a; var m = MMU.rb((Z80._r.h << 8) + Z80._r.l); i -= m; Z80._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ i ^ m) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 2; }
            public static void CPn() { var i = Z80._r.a; var m = MMU.rb(Z80._r.pc); i -= m; Z80._r.pc++; Z80._r.f = (i < 0) ? 0x50 : 0x40; i &= 255; if (i == 0) Z80._r.f |= 0x80; if (((Z80._r.a ^ i ^ m) & 0x10) != 0) Z80._r.f |= 0x20; Z80._r.m = 2; }

            public static void DAA() { var a = Z80._r.a; if (((Z80._r.f & 0x20) != 0) || ((Z80._r.a & 15) > 9)) Z80._r.a += 6; Z80._r.f &= 0xEF; if (((Z80._r.f & 0x20) != 0) || (a > 0x99)) { Z80._r.a += 0x60; Z80._r.f |= 0x10; } Z80._r.m = 1; }

            public static void ANDr_b() { Z80._r.a &= Z80._r.b; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void ANDr_c() { Z80._r.a &= Z80._r.c; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void ANDr_d() { Z80._r.a &= Z80._r.d; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void ANDr_e() { Z80._r.a &= Z80._r.e; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void ANDr_h() { Z80._r.a &= Z80._r.h; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void ANDr_l() { Z80._r.a &= Z80._r.l; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void ANDr_a() { Z80._r.a &= Z80._r.a; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void ANDHL() { Z80._r.a &= MMU.rb((Z80._r.h << 8) + Z80._r.l); Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void ANDn() { Z80._r.a &= MMU.rb(Z80._r.pc); Z80._r.pc++; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 2; }

            public static void ORr_b() { Z80._r.a |= Z80._r.b; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void ORr_c() { Z80._r.a |= Z80._r.c; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void ORr_d() { Z80._r.a |= Z80._r.d; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void ORr_e() { Z80._r.a |= Z80._r.e; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void ORr_h() { Z80._r.a |= Z80._r.h; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void ORr_l() { Z80._r.a |= Z80._r.l; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void ORr_a() { Z80._r.a |= Z80._r.a; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void ORHL() { Z80._r.a |= MMU.rb((Z80._r.h << 8) + Z80._r.l); Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void ORn() { Z80._r.a |= MMU.rb(Z80._r.pc); Z80._r.pc++; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 2; }

            public static void XORr_b() { Z80._r.a ^= Z80._r.b; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void XORr_c() { Z80._r.a ^= Z80._r.c; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void XORr_d() { Z80._r.a ^= Z80._r.d; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void XORr_e() { Z80._r.a ^= Z80._r.e; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void XORr_h() { Z80._r.a ^= Z80._r.h; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void XORr_l() { Z80._r.a ^= Z80._r.l; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void XORr_a() { Z80._r.a ^= Z80._r.a; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void XORHL() { Z80._r.a ^= MMU.rb((Z80._r.h << 8) + Z80._r.l); Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void XORn() { Z80._r.a ^= MMU.rb(Z80._r.pc); Z80._r.pc++; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 2; }

            public static void INCr_b() { Z80._r.b++; Z80._r.b &= 255; Z80._r.f = Z80._r.b != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void INCr_c() { Z80._r.c++; Z80._r.c &= 255; Z80._r.f = Z80._r.c != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void INCr_d() { Z80._r.d++; Z80._r.d &= 255; Z80._r.f = Z80._r.d != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void INCr_e() { Z80._r.e++; Z80._r.e &= 255; Z80._r.f = Z80._r.e != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void INCr_h() { Z80._r.h++; Z80._r.h &= 255; Z80._r.f = Z80._r.h != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void INCr_l() { Z80._r.l++; Z80._r.l &= 255; Z80._r.f = Z80._r.l != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void INCr_a() { Z80._r.a++; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void INCHLm() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l) + 1; i &= 255; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.f = i != 0 ? 0 : 0x80; Z80._r.m = 3; }

            public static void DECr_b() { Z80._r.b--; Z80._r.b &= 255; Z80._r.f = Z80._r.b != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void DECr_c() { Z80._r.c--; Z80._r.c &= 255; Z80._r.f = Z80._r.c != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void DECr_d() { Z80._r.d--; Z80._r.d &= 255; Z80._r.f = Z80._r.d != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void DECr_e() { Z80._r.e--; Z80._r.e &= 255; Z80._r.f = Z80._r.e != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void DECr_h() { Z80._r.h--; Z80._r.h &= 255; Z80._r.f = Z80._r.h != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void DECr_l() { Z80._r.l--; Z80._r.l &= 255; Z80._r.f = Z80._r.l != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void DECr_a() { Z80._r.a--; Z80._r.a &= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void DECHLm() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l) - 1; i &= 255; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.f = i != 0 ? 0 : 0x80; Z80._r.m = 3; }

            public static void INCBC() { Z80._r.c = (Z80._r.c + 1) & 255; if (!(Z80._r.c != 0)) Z80._r.b = (Z80._r.b + 1) & 255; Z80._r.m = 1; }
            public static void INCDE() { Z80._r.e = (Z80._r.e + 1) & 255; if (!(Z80._r.e != 0)) Z80._r.d = (Z80._r.d + 1) & 255; Z80._r.m = 1; }
            public static void INCHL() { Z80._r.l = (Z80._r.l + 1) & 255; if (!(Z80._r.l != 0)) Z80._r.h = (Z80._r.h + 1) & 255; Z80._r.m = 1; }
            public static void INCSP() { Z80._r.sp = (Z80._r.sp + 1) & 65535; Z80._r.m = 1; }

            public static void DECBC() { Z80._r.c = (Z80._r.c - 1) & 255; if (Z80._r.c == 255) Z80._r.b = (Z80._r.b - 1) & 255; Z80._r.m = 1; }
            public static void DECDE() { Z80._r.e = (Z80._r.e - 1) & 255; if (Z80._r.e == 255) Z80._r.d = (Z80._r.d - 1) & 255; Z80._r.m = 1; }
            public static void DECHL() { Z80._r.l = (Z80._r.l - 1) & 255; if (Z80._r.l == 255) Z80._r.h = (Z80._r.h - 1) & 255; Z80._r.m = 1; }
            public static void DECSP() { Z80._r.sp = (Z80._r.sp - 1) & 65535; Z80._r.m = 1; }

            /*--- Bit manipulation ---*/
            public static void BIT0b() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.b & 0x01) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT0c() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.c & 0x01) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT0d() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.d & 0x01) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT0e() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.e & 0x01) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT0h() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.h & 0x01) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT0l() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.l & 0x01) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT0a() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.a & 0x01) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT0m() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (MMU.rb((Z80._r.h << 8) + Z80._r.l) & 0x01) != 0 ? 0 : 0x80; Z80._r.m = 3; }

            public static void RES0b() { Z80._r.b &= 0xFE; Z80._r.m = 2; }
            public static void RES0c() { Z80._r.c &= 0xFE; Z80._r.m = 2; }
            public static void RES0d() { Z80._r.d &= 0xFE; Z80._r.m = 2; }
            public static void RES0e() { Z80._r.e &= 0xFE; Z80._r.m = 2; }
            public static void RES0h() { Z80._r.h &= 0xFE; Z80._r.m = 2; }
            public static void RES0l() { Z80._r.l &= 0xFE; Z80._r.m = 2; }
            public static void RES0a() { Z80._r.a &= 0xFE; Z80._r.m = 2; }
            public static void RES0m() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); i &= 0xFE; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.m = 4; }

            public static void SET0b() { Z80._r.b |= 0x01; Z80._r.m = 2; }
            public static void SET0c() { Z80._r.b |= 0x01; Z80._r.m = 2; }
            public static void SET0d() { Z80._r.b |= 0x01; Z80._r.m = 2; }
            public static void SET0e() { Z80._r.b |= 0x01; Z80._r.m = 2; }
            public static void SET0h() { Z80._r.b |= 0x01; Z80._r.m = 2; }
            public static void SET0l() { Z80._r.b |= 0x01; Z80._r.m = 2; }
            public static void SET0a() { Z80._r.b |= 0x01; Z80._r.m = 2; }
            public static void SET0m() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); i |= 0x01; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.m = 4; }

            public static void BIT1b() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.b & 0x02) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT1c() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.c & 0x02) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT1d() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.d & 0x02) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT1e() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.e & 0x02) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT1h() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.h & 0x02) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT1l() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.l & 0x02) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT1a() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.a & 0x02) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT1m() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (MMU.rb((Z80._r.h << 8) + Z80._r.l) & 0x02) != 0 ? 0 : 0x80; Z80._r.m = 3; }

            public static void RES1b() { Z80._r.b &= 0xFD; Z80._r.m = 2; }
            public static void RES1c() { Z80._r.c &= 0xFD; Z80._r.m = 2; }
            public static void RES1d() { Z80._r.d &= 0xFD; Z80._r.m = 2; }
            public static void RES1e() { Z80._r.e &= 0xFD; Z80._r.m = 2; }
            public static void RES1h() { Z80._r.h &= 0xFD; Z80._r.m = 2; }
            public static void RES1l() { Z80._r.l &= 0xFD; Z80._r.m = 2; }
            public static void RES1a() { Z80._r.a &= 0xFD; Z80._r.m = 2; }
            public static void RES1m() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); i &= 0xFD; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.m = 4; }

            public static void SET1b() { Z80._r.b |= 0x02; Z80._r.m = 2; }
            public static void SET1c() { Z80._r.b |= 0x02; Z80._r.m = 2; }
            public static void SET1d() { Z80._r.b |= 0x02; Z80._r.m = 2; }
            public static void SET1e() { Z80._r.b |= 0x02; Z80._r.m = 2; }
            public static void SET1h() { Z80._r.b |= 0x02; Z80._r.m = 2; }
            public static void SET1l() { Z80._r.b |= 0x02; Z80._r.m = 2; }
            public static void SET1a() { Z80._r.b |= 0x02; Z80._r.m = 2; }
            public static void SET1m() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); i |= 0x02; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.m = 4; }

            public static void BIT2b() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.b & 0x04) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT2c() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.c & 0x04) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT2d() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.d & 0x04) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT2e() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.e & 0x04) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT2h() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.h & 0x04) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT2l() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.l & 0x04) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT2a() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.a & 0x04) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT2m() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (MMU.rb((Z80._r.h << 8) + Z80._r.l) & 0x04) != 0 ? 0 : 0x80; Z80._r.m = 3; }

            public static void RES2b() { Z80._r.b &= 0xFB; Z80._r.m = 2; }
            public static void RES2c() { Z80._r.c &= 0xFB; Z80._r.m = 2; }
            public static void RES2d() { Z80._r.d &= 0xFB; Z80._r.m = 2; }
            public static void RES2e() { Z80._r.e &= 0xFB; Z80._r.m = 2; }
            public static void RES2h() { Z80._r.h &= 0xFB; Z80._r.m = 2; }
            public static void RES2l() { Z80._r.l &= 0xFB; Z80._r.m = 2; }
            public static void RES2a() { Z80._r.a &= 0xFB; Z80._r.m = 2; }
            public static void RES2m() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); i &= 0xFB; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.m = 4; }

            public static void SET2b() { Z80._r.b |= 0x04; Z80._r.m = 2; }
            public static void SET2c() { Z80._r.b |= 0x04; Z80._r.m = 2; }
            public static void SET2d() { Z80._r.b |= 0x04; Z80._r.m = 2; }
            public static void SET2e() { Z80._r.b |= 0x04; Z80._r.m = 2; }
            public static void SET2h() { Z80._r.b |= 0x04; Z80._r.m = 2; }
            public static void SET2l() { Z80._r.b |= 0x04; Z80._r.m = 2; }
            public static void SET2a() { Z80._r.b |= 0x04; Z80._r.m = 2; }
            public static void SET2m() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); i |= 0x04; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.m = 4; }

            public static void BIT3b() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.b & 0x08) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT3c() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.c & 0x08) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT3d() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.d & 0x08) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT3e() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.e & 0x08) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT3h() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.h & 0x08) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT3l() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.l & 0x08) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT3a() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.a & 0x08) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT3m() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (MMU.rb((Z80._r.h << 8) + Z80._r.l) & 0x08) != 0 ? 0 : 0x80; Z80._r.m = 3; }

            public static void RES3b() { Z80._r.b &= 0xF7; Z80._r.m = 2; }
            public static void RES3c() { Z80._r.c &= 0xF7; Z80._r.m = 2; }
            public static void RES3d() { Z80._r.d &= 0xF7; Z80._r.m = 2; }
            public static void RES3e() { Z80._r.e &= 0xF7; Z80._r.m = 2; }
            public static void RES3h() { Z80._r.h &= 0xF7; Z80._r.m = 2; }
            public static void RES3l() { Z80._r.l &= 0xF7; Z80._r.m = 2; }
            public static void RES3a() { Z80._r.a &= 0xF7; Z80._r.m = 2; }
            public static void RES3m() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); i &= 0xF7; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.m = 4; }

            public static void SET3b() { Z80._r.b |= 0x08; Z80._r.m = 2; }
            public static void SET3c() { Z80._r.b |= 0x08; Z80._r.m = 2; }
            public static void SET3d() { Z80._r.b |= 0x08; Z80._r.m = 2; }
            public static void SET3e() { Z80._r.b |= 0x08; Z80._r.m = 2; }
            public static void SET3h() { Z80._r.b |= 0x08; Z80._r.m = 2; }
            public static void SET3l() { Z80._r.b |= 0x08; Z80._r.m = 2; }
            public static void SET3a() { Z80._r.b |= 0x08; Z80._r.m = 2; }
            public static void SET3m() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); i |= 0x08; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.m = 4; }

            public static void BIT4b() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.b & 0x10) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT4c() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.c & 0x10) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT4d() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.d & 0x10) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT4e() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.e & 0x10) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT4h() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.h & 0x10) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT4l() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.l & 0x10) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT4a() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.a & 0x10) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT4m() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (MMU.rb((Z80._r.h << 8) + Z80._r.l) & 0x10) != 0 ? 0 : 0x80; Z80._r.m = 3; }

            public static void RES4b() { Z80._r.b &= 0xEF; Z80._r.m = 2; }
            public static void RES4c() { Z80._r.c &= 0xEF; Z80._r.m = 2; }
            public static void RES4d() { Z80._r.d &= 0xEF; Z80._r.m = 2; }
            public static void RES4e() { Z80._r.e &= 0xEF; Z80._r.m = 2; }
            public static void RES4h() { Z80._r.h &= 0xEF; Z80._r.m = 2; }
            public static void RES4l() { Z80._r.l &= 0xEF; Z80._r.m = 2; }
            public static void RES4a() { Z80._r.a &= 0xEF; Z80._r.m = 2; }
            public static void RES4m() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); i &= 0xEF; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.m = 4; }

            public static void SET4b() { Z80._r.b |= 0x10; Z80._r.m = 2; }
            public static void SET4c() { Z80._r.b |= 0x10; Z80._r.m = 2; }
            public static void SET4d() { Z80._r.b |= 0x10; Z80._r.m = 2; }
            public static void SET4e() { Z80._r.b |= 0x10; Z80._r.m = 2; }
            public static void SET4h() { Z80._r.b |= 0x10; Z80._r.m = 2; }
            public static void SET4l() { Z80._r.b |= 0x10; Z80._r.m = 2; }
            public static void SET4a() { Z80._r.b |= 0x10; Z80._r.m = 2; }
            public static void SET4m() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); i |= 0x10; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.m = 4; }

            public static void BIT5b() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.b & 0x20) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT5c() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.c & 0x20) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT5d() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.d & 0x20) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT5e() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.e & 0x20) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT5h() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.h & 0x20) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT5l() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.l & 0x20) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT5a() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.a & 0x20) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT5m() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (MMU.rb((Z80._r.h << 8) + Z80._r.l) & 0x20) != 0 ? 0 : 0x80; Z80._r.m = 3; }

            public static void RES5b() { Z80._r.b &= 0xDF; Z80._r.m = 2; }
            public static void RES5c() { Z80._r.c &= 0xDF; Z80._r.m = 2; }
            public static void RES5d() { Z80._r.d &= 0xDF; Z80._r.m = 2; }
            public static void RES5e() { Z80._r.e &= 0xDF; Z80._r.m = 2; }
            public static void RES5h() { Z80._r.h &= 0xDF; Z80._r.m = 2; }
            public static void RES5l() { Z80._r.l &= 0xDF; Z80._r.m = 2; }
            public static void RES5a() { Z80._r.a &= 0xDF; Z80._r.m = 2; }
            public static void RES5m() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); i &= 0xDF; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.m = 4; }

            public static void SET5b() { Z80._r.b |= 0x20; Z80._r.m = 2; }
            public static void SET5c() { Z80._r.b |= 0x20; Z80._r.m = 2; }
            public static void SET5d() { Z80._r.b |= 0x20; Z80._r.m = 2; }
            public static void SET5e() { Z80._r.b |= 0x20; Z80._r.m = 2; }
            public static void SET5h() { Z80._r.b |= 0x20; Z80._r.m = 2; }
            public static void SET5l() { Z80._r.b |= 0x20; Z80._r.m = 2; }
            public static void SET5a() { Z80._r.b |= 0x20; Z80._r.m = 2; }
            public static void SET5m() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); i |= 0x20; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.m = 4; }

            public static void BIT6b() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.b & 0x40) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT6c() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.c & 0x40) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT6d() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.d & 0x40) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT6e() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.e & 0x40) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT6h() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.h & 0x40) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT6l() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.l & 0x40) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT6a() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.a & 0x40) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT6m() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (MMU.rb((Z80._r.h << 8) + Z80._r.l) & 0x40) != 0 ? 0 : 0x80; Z80._r.m = 3; }

            public static void RES6b() { Z80._r.b &= 0xBF; Z80._r.m = 2; }
            public static void RES6c() { Z80._r.c &= 0xBF; Z80._r.m = 2; }
            public static void RES6d() { Z80._r.d &= 0xBF; Z80._r.m = 2; }
            public static void RES6e() { Z80._r.e &= 0xBF; Z80._r.m = 2; }
            public static void RES6h() { Z80._r.h &= 0xBF; Z80._r.m = 2; }
            public static void RES6l() { Z80._r.l &= 0xBF; Z80._r.m = 2; }
            public static void RES6a() { Z80._r.a &= 0xBF; Z80._r.m = 2; }
            public static void RES6m() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); i &= 0xBF; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.m = 4; }

            public static void SET6b() { Z80._r.b |= 0x40; Z80._r.m = 2; }
            public static void SET6c() { Z80._r.b |= 0x40; Z80._r.m = 2; }
            public static void SET6d() { Z80._r.b |= 0x40; Z80._r.m = 2; }
            public static void SET6e() { Z80._r.b |= 0x40; Z80._r.m = 2; }
            public static void SET6h() { Z80._r.b |= 0x40; Z80._r.m = 2; }
            public static void SET6l() { Z80._r.b |= 0x40; Z80._r.m = 2; }
            public static void SET6a() { Z80._r.b |= 0x40; Z80._r.m = 2; }
            public static void SET6m() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); i |= 0x40; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.m = 4; }

            public static void BIT7b() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.b & 0x80) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT7c() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.c & 0x80) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT7d() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.d & 0x80) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT7e() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.e & 0x80) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT7h() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.h & 0x80) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT7l() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.l & 0x80) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT7a() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (Z80._r.a & 0x80) != 0 ? 0 : 0x80; Z80._r.m = 2; }
            public static void BIT7m() { Z80._r.f &= 0x1F; Z80._r.f |= 0x20; Z80._r.f = (MMU.rb((Z80._r.h << 8) + Z80._r.l) & 0x80) != 0 ? 0 : 0x80; Z80._r.m = 3; }

            public static void RES7b() { Z80._r.b &= 0x7F; Z80._r.m = 2; }
            public static void RES7c() { Z80._r.c &= 0x7F; Z80._r.m = 2; }
            public static void RES7d() { Z80._r.d &= 0x7F; Z80._r.m = 2; }
            public static void RES7e() { Z80._r.e &= 0x7F; Z80._r.m = 2; }
            public static void RES7h() { Z80._r.h &= 0x7F; Z80._r.m = 2; }
            public static void RES7l() { Z80._r.l &= 0x7F; Z80._r.m = 2; }
            public static void RES7a() { Z80._r.a &= 0x7F; Z80._r.m = 2; }
            public static void RES7m() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); i &= 0x7F; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.m = 4; }

            public static void SET7b() { Z80._r.b |= 0x80; Z80._r.m = 2; }
            public static void SET7c() { Z80._r.b |= 0x80; Z80._r.m = 2; }
            public static void SET7d() { Z80._r.b |= 0x80; Z80._r.m = 2; }
            public static void SET7e() { Z80._r.b |= 0x80; Z80._r.m = 2; }
            public static void SET7h() { Z80._r.b |= 0x80; Z80._r.m = 2; }
            public static void SET7l() { Z80._r.b |= 0x80; Z80._r.m = 2; }
            public static void SET7a() { Z80._r.b |= 0x80; Z80._r.m = 2; }
            public static void SET7m() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); i |= 0x80; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.m = 4; }

            public static void RLA() { var ci = (Z80._r.f & 0x10) != 0 ? 1 : 0; var co = (Z80._r.a & 0x80) != 0 ? 0x10 : 0; Z80._r.a = (Z80._r.a << 1) + ci; Z80._r.a &= 255; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 1; }
            public static void RLCA() { var ci = (Z80._r.a & 0x80) != 0 ? 1 : 0; var co = (Z80._r.a & 0x80) != 0 ? 0x10 : 0; Z80._r.a = (Z80._r.a << 1) + ci; Z80._r.a &= 255; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 1; }
            public static void RRA() { var ci = (Z80._r.f & 0x10) != 0 ? 0x80 : 0; var co = (Z80._r.a & 1) != 0 ? 0x10 : 0; Z80._r.a = (Z80._r.a >> 1) + ci; Z80._r.a &= 255; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 1; }
            public static void RRCA() { var ci = (Z80._r.a & 1) != 0 ? 0x80 : 0; var co = (Z80._r.a & 1) != 0 ? 0x10 : 0; Z80._r.a = (Z80._r.a >> 1) + ci; Z80._r.a &= 255; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 1; }

            public static void RLr_b() { var ci = (Z80._r.f & 0x10) != 0 ? 1 : 0; var co = (Z80._r.b & 0x80) != 0 ? 0x10 : 0; Z80._r.b = (Z80._r.b << 1) + ci; Z80._r.b &= 255; Z80._r.f = (Z80._r.b) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RLr_c() { var ci = (Z80._r.f & 0x10) != 0 ? 1 : 0; var co = (Z80._r.c & 0x80) != 0 ? 0x10 : 0; Z80._r.c = (Z80._r.c << 1) + ci; Z80._r.c &= 255; Z80._r.f = (Z80._r.c) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RLr_d() { var ci = (Z80._r.f & 0x10) != 0 ? 1 : 0; var co = (Z80._r.d & 0x80) != 0 ? 0x10 : 0; Z80._r.d = (Z80._r.d << 1) + ci; Z80._r.d &= 255; Z80._r.f = (Z80._r.d) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RLr_e() { var ci = (Z80._r.f & 0x10) != 0 ? 1 : 0; var co = (Z80._r.e & 0x80) != 0 ? 0x10 : 0; Z80._r.e = (Z80._r.e << 1) + ci; Z80._r.e &= 255; Z80._r.f = (Z80._r.e) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RLr_h() { var ci = (Z80._r.f & 0x10) != 0 ? 1 : 0; var co = (Z80._r.h & 0x80) != 0 ? 0x10 : 0; Z80._r.h = (Z80._r.h << 1) + ci; Z80._r.h &= 255; Z80._r.f = (Z80._r.h) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RLr_l() { var ci = (Z80._r.f & 0x10) != 0 ? 1 : 0; var co = (Z80._r.l & 0x80) != 0 ? 0x10 : 0; Z80._r.l = (Z80._r.l << 1) + ci; Z80._r.l &= 255; Z80._r.f = (Z80._r.l) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RLr_a() { var ci = (Z80._r.f & 0x10) != 0 ? 1 : 0; var co = (Z80._r.a & 0x80) != 0 ? 0x10 : 0; Z80._r.a = (Z80._r.a << 1) + ci; Z80._r.a &= 255; Z80._r.f = (Z80._r.a) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RLHL() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); var ci = (Z80._r.f & 0x10) != 0 ? 1 : 0; var co = (i & 0x80) != 0 ? 0x10 : 0; i = (i << 1) + ci; i &= 255; Z80._r.f = (i) != 0 ? 0 : 0x80; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 4; }

            public static void RLCr_b() { var ci = (Z80._r.b & 0x80) != 0 ? 1 : 0; var co = (Z80._r.b & 0x80) != 0 ? 0x10 : 0; Z80._r.b = (Z80._r.b << 1) + ci; Z80._r.b &= 255; Z80._r.f = (Z80._r.b) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RLCr_c() { var ci = (Z80._r.c & 0x80) != 0 ? 1 : 0; var co = (Z80._r.c & 0x80) != 0 ? 0x10 : 0; Z80._r.c = (Z80._r.c << 1) + ci; Z80._r.c &= 255; Z80._r.f = (Z80._r.c) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RLCr_d() { var ci = (Z80._r.d & 0x80) != 0 ? 1 : 0; var co = (Z80._r.d & 0x80) != 0 ? 0x10 : 0; Z80._r.d = (Z80._r.d << 1) + ci; Z80._r.d &= 255; Z80._r.f = (Z80._r.d) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RLCr_e() { var ci = (Z80._r.e & 0x80) != 0 ? 1 : 0; var co = (Z80._r.e & 0x80) != 0 ? 0x10 : 0; Z80._r.e = (Z80._r.e << 1) + ci; Z80._r.e &= 255; Z80._r.f = (Z80._r.e) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RLCr_h() { var ci = (Z80._r.h & 0x80) != 0 ? 1 : 0; var co = (Z80._r.h & 0x80) != 0 ? 0x10 : 0; Z80._r.h = (Z80._r.h << 1) + ci; Z80._r.h &= 255; Z80._r.f = (Z80._r.h) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RLCr_l() { var ci = (Z80._r.l & 0x80) != 0 ? 1 : 0; var co = (Z80._r.l & 0x80) != 0 ? 0x10 : 0; Z80._r.l = (Z80._r.l << 1) + ci; Z80._r.l &= 255; Z80._r.f = (Z80._r.l) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RLCr_a() { var ci = (Z80._r.a & 0x80) != 0 ? 1 : 0; var co = (Z80._r.a & 0x80) != 0 ? 0x10 : 0; Z80._r.a = (Z80._r.a << 1) + ci; Z80._r.a &= 255; Z80._r.f = (Z80._r.a) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RLCHL() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); var ci = (i & 0x80) != 0 ? 1 : 0; var co = (i & 0x80) != 0 ? 0x10 : 0; i = (i << 1) + ci; i &= 255; Z80._r.f = (i) != 0 ? 0 : 0x80; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 4; }

            public static void RRr_b() { var ci = (Z80._r.f & 0x10) != 0 ? 0x80 : 0; var co = (Z80._r.b & 1) != 0 ? 0x10 : 0; Z80._r.b = (Z80._r.b >> 1) + ci; Z80._r.b &= 255; Z80._r.f = (Z80._r.b != 0) ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RRr_c() { var ci = (Z80._r.f & 0x10) != 0 ? 0x80 : 0; var co = (Z80._r.c & 1) != 0 ? 0x10 : 0; Z80._r.c = (Z80._r.c >> 1) + ci; Z80._r.c &= 255; Z80._r.f = (Z80._r.c != 0) ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RRr_d() { var ci = (Z80._r.f & 0x10) != 0 ? 0x80 : 0; var co = (Z80._r.d & 1) != 0 ? 0x10 : 0; Z80._r.d = (Z80._r.d >> 1) + ci; Z80._r.d &= 255; Z80._r.f = (Z80._r.d != 0) ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RRr_e() { var ci = (Z80._r.f & 0x10) != 0 ? 0x80 : 0; var co = (Z80._r.e & 1) != 0 ? 0x10 : 0; Z80._r.e = (Z80._r.e >> 1) + ci; Z80._r.e &= 255; Z80._r.f = (Z80._r.e != 0) ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RRr_h() { var ci = (Z80._r.f & 0x10) != 0 ? 0x80 : 0; var co = (Z80._r.h & 1) != 0 ? 0x10 : 0; Z80._r.h = (Z80._r.h >> 1) + ci; Z80._r.h &= 255; Z80._r.f = (Z80._r.h != 0) ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RRr_l() { var ci = (Z80._r.f & 0x10) != 0 ? 0x80 : 0; var co = (Z80._r.l & 1) != 0 ? 0x10 : 0; Z80._r.l = (Z80._r.l >> 1) + ci; Z80._r.l &= 255; Z80._r.f = (Z80._r.l != 0) ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RRr_a() { var ci = (Z80._r.f & 0x10) != 0 ? 0x80 : 0; var co = (Z80._r.a & 1) != 0 ? 0x10 : 0; Z80._r.a = (Z80._r.a >> 1) + ci; Z80._r.a &= 255; Z80._r.f = (Z80._r.a != 0) ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RRHL() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); var ci = (Z80._r.f & 0x10) != 0 ? 0x80 : 0; var co = (i & 1) != 0 ? 0x10 : 0; i = (i >> 1) + ci; i &= 255; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.f = (i) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 4; }

            public static void RRCr_b() { var ci = (Z80._r.b & 1) != 0 ? 0x80 : 0; var co = (Z80._r.b & 1) != 0 ? 0x10 : 0; Z80._r.b = (Z80._r.b >> 1) + ci; Z80._r.b &= 255; Z80._r.f = (Z80._r.b) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RRCr_c() { var ci = (Z80._r.c & 1) != 0 ? 0x80 : 0; var co = (Z80._r.c & 1) != 0 ? 0x10 : 0; Z80._r.c = (Z80._r.c >> 1) + ci; Z80._r.c &= 255; Z80._r.f = (Z80._r.c) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RRCr_d() { var ci = (Z80._r.d & 1) != 0 ? 0x80 : 0; var co = (Z80._r.d & 1) != 0 ? 0x10 : 0; Z80._r.d = (Z80._r.d >> 1) + ci; Z80._r.d &= 255; Z80._r.f = (Z80._r.d) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RRCr_e() { var ci = (Z80._r.e & 1) != 0 ? 0x80 : 0; var co = (Z80._r.e & 1) != 0 ? 0x10 : 0; Z80._r.e = (Z80._r.e >> 1) + ci; Z80._r.e &= 255; Z80._r.f = (Z80._r.e) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RRCr_h() { var ci = (Z80._r.h & 1) != 0 ? 0x80 : 0; var co = (Z80._r.h & 1) != 0 ? 0x10 : 0; Z80._r.h = (Z80._r.h >> 1) + ci; Z80._r.h &= 255; Z80._r.f = (Z80._r.h) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RRCr_l() { var ci = (Z80._r.l & 1) != 0 ? 0x80 : 0; var co = (Z80._r.l & 1) != 0 ? 0x10 : 0; Z80._r.l = (Z80._r.l >> 1) + ci; Z80._r.l &= 255; Z80._r.f = (Z80._r.l) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RRCr_a() { var ci = (Z80._r.a & 1) != 0 ? 0x80 : 0; var co = (Z80._r.a & 1) != 0 ? 0x10 : 0; Z80._r.a = (Z80._r.a >> 1) + ci; Z80._r.a &= 255; Z80._r.f = (Z80._r.a) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void RRCHL() { var i = MMU.rb((Z80._r.h << 8) + Z80._r.l); var ci = (i & 1) != 0 ? 0x80 : 0; var co = (i & 1) != 0 ? 0x10 : 0; i = (i >> 1) + ci; i &= 255; MMU.wb((Z80._r.h << 8) + Z80._r.l, i); Z80._r.f = (i) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 4; }

            public static void SLAr_b() { var co = (Z80._r.b & 0x80) != 0 ? 0x10 : 0; Z80._r.b = (Z80._r.b << 1) & 255; Z80._r.f = (Z80._r.b) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SLAr_c() { var co = (Z80._r.c & 0x80) != 0 ? 0x10 : 0; Z80._r.c = (Z80._r.c << 1) & 255; Z80._r.f = (Z80._r.c) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SLAr_d() { var co = (Z80._r.d & 0x80) != 0 ? 0x10 : 0; Z80._r.d = (Z80._r.d << 1) & 255; Z80._r.f = (Z80._r.d) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SLAr_e() { var co = (Z80._r.e & 0x80) != 0 ? 0x10 : 0; Z80._r.e = (Z80._r.e << 1) & 255; Z80._r.f = (Z80._r.e) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SLAr_h() { var co = (Z80._r.h & 0x80) != 0 ? 0x10 : 0; Z80._r.h = (Z80._r.h << 1) & 255; Z80._r.f = (Z80._r.h) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SLAr_l() { var co = (Z80._r.l & 0x80) != 0 ? 0x10 : 0; Z80._r.l = (Z80._r.l << 1) & 255; Z80._r.f = (Z80._r.l) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SLAr_a() { var co = (Z80._r.a & 0x80) != 0 ? 0x10 : 0; Z80._r.a = (Z80._r.a << 1) & 255; Z80._r.f = (Z80._r.a) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }

            public static void SLLr_b() { var co = (Z80._r.b & 0x80) != 0 ? 0x10 : 0; Z80._r.b = (Z80._r.b << 1) & 255 + 1; Z80._r.f = (Z80._r.b) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SLLr_c() { var co = (Z80._r.c & 0x80) != 0 ? 0x10 : 0; Z80._r.c = (Z80._r.c << 1) & 255 + 1; Z80._r.f = (Z80._r.c) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SLLr_d() { var co = (Z80._r.d & 0x80) != 0 ? 0x10 : 0; Z80._r.d = (Z80._r.d << 1) & 255 + 1; Z80._r.f = (Z80._r.d) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SLLr_e() { var co = (Z80._r.e & 0x80) != 0 ? 0x10 : 0; Z80._r.e = (Z80._r.e << 1) & 255 + 1; Z80._r.f = (Z80._r.e) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SLLr_h() { var co = (Z80._r.h & 0x80) != 0 ? 0x10 : 0; Z80._r.h = (Z80._r.h << 1) & 255 + 1; Z80._r.f = (Z80._r.h) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SLLr_l() { var co = (Z80._r.l & 0x80) != 0 ? 0x10 : 0; Z80._r.l = (Z80._r.l << 1) & 255 + 1; Z80._r.f = (Z80._r.l) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SLLr_a() { var co = (Z80._r.a & 0x80) != 0 ? 0x10 : 0; Z80._r.a = (Z80._r.a << 1) & 255 + 1; Z80._r.f = (Z80._r.a) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }

            public static void SRAr_b() { var ci = Z80._r.b & 0x80; var co = (Z80._r.b & 1) !=0 ? 0x10 : 0; Z80._r.b = ((Z80._r.b >> 1) + ci) & 255; Z80._r.f = (Z80._r.b) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SRAr_c() { var ci = Z80._r.c & 0x80; var co = (Z80._r.c & 1) !=0 ? 0x10 : 0; Z80._r.c = ((Z80._r.c >> 1) + ci) & 255; Z80._r.f = (Z80._r.c) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SRAr_d() { var ci = Z80._r.d & 0x80; var co = (Z80._r.d & 1) !=0 ? 0x10 : 0; Z80._r.d = ((Z80._r.d >> 1) + ci) & 255; Z80._r.f = (Z80._r.d) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SRAr_e() { var ci = Z80._r.e & 0x80; var co = (Z80._r.e & 1) !=0 ? 0x10 : 0; Z80._r.e = ((Z80._r.e >> 1) + ci) & 255; Z80._r.f = (Z80._r.e) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SRAr_h() { var ci = Z80._r.h & 0x80; var co = (Z80._r.h & 1) !=0 ? 0x10 : 0; Z80._r.h = ((Z80._r.h >> 1) + ci) & 255; Z80._r.f = (Z80._r.h) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SRAr_l() { var ci = Z80._r.l & 0x80; var co = (Z80._r.l & 1) !=0 ? 0x10 : 0; Z80._r.l = ((Z80._r.l >> 1) + ci) & 255; Z80._r.f = (Z80._r.l) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SRAr_a() { var ci = Z80._r.a & 0x80; var co = (Z80._r.a & 1) !=0 ? 0x10 : 0; Z80._r.a = ((Z80._r.a >> 1) + ci) & 255; Z80._r.f = (Z80._r.a) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }

            public static void SRLr_b() { var co = (Z80._r.b & 1) != 0 ? 0x10 : 0; Z80._r.b = (Z80._r.b >> 1) & 255; Z80._r.f = (Z80._r.b) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SRLr_c() { var co = (Z80._r.c & 1) != 0 ? 0x10 : 0; Z80._r.c = (Z80._r.c >> 1) & 255; Z80._r.f = (Z80._r.c) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SRLr_d() { var co = (Z80._r.d & 1) != 0 ? 0x10 : 0; Z80._r.d = (Z80._r.d >> 1) & 255; Z80._r.f = (Z80._r.d) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SRLr_e() { var co = (Z80._r.e & 1) != 0 ? 0x10 : 0; Z80._r.e = (Z80._r.e >> 1) & 255; Z80._r.f = (Z80._r.e) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SRLr_h() { var co = (Z80._r.h & 1) != 0 ? 0x10 : 0; Z80._r.h = (Z80._r.h >> 1) & 255; Z80._r.f = (Z80._r.h) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SRLr_l() { var co = (Z80._r.l & 1) != 0 ? 0x10 : 0; Z80._r.l = (Z80._r.l >> 1) & 255; Z80._r.f = (Z80._r.l) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }
            public static void SRLr_a() { var co = (Z80._r.a & 1) != 0 ? 0x10 : 0; Z80._r.a = (Z80._r.a >> 1) & 255; Z80._r.f = (Z80._r.a) != 0 ? 0 : 0x80; Z80._r.f = (Z80._r.f & 0xEF) + co; Z80._r.m = 2; }

            public static void CPL() { Z80._r.a ^= 255; Z80._r.f = Z80._r.a != 0 ? 0 : 0x80; Z80._r.m = 1; }
            public static void NEG() { Z80._r.a = 0 - Z80._r.a; Z80._r.f = (Z80._r.a < 0) ? 0x10 : 0; Z80._r.a &= 255; if (!(Z80._r.a != 0)) Z80._r.f |= 0x80; Z80._r.m = 2; }

            public static void CCF() { var ci = (Z80._r.f & 0x10) != 0 ? 0 : 0x10; Z80._r.f = (Z80._r.f & 0xEF) + ci; Z80._r.m = 1; }
            public static void SCF() { Z80._r.f |= 0x10; Z80._r.m = 1; }

            /*--- Stack ---*/
            public static void PUSHBC() { Z80._r.sp--; MMU.wb(Z80._r.sp, Z80._r.b); Z80._r.sp--; MMU.wb(Z80._r.sp, Z80._r.c); Z80._r.m = 3; }
            public static void PUSHDE() { Z80._r.sp--; MMU.wb(Z80._r.sp, Z80._r.d); Z80._r.sp--; MMU.wb(Z80._r.sp, Z80._r.e); Z80._r.m = 3; }
            public static void PUSHHL() { Z80._r.sp--; MMU.wb(Z80._r.sp, Z80._r.h); Z80._r.sp--; MMU.wb(Z80._r.sp, Z80._r.l); Z80._r.m = 3; }
            public static void PUSHAF() { Z80._r.sp--; MMU.wb(Z80._r.sp, Z80._r.a); Z80._r.sp--; MMU.wb(Z80._r.sp, Z80._r.f); Z80._r.m = 3; }

            public static void POPBC() { Z80._r.c = MMU.rb(Z80._r.sp); Z80._r.sp++; Z80._r.b = MMU.rb(Z80._r.sp); Z80._r.sp++; Z80._r.m = 3; }
            public static void POPDE() { Z80._r.e = MMU.rb(Z80._r.sp); Z80._r.sp++; Z80._r.d = MMU.rb(Z80._r.sp); Z80._r.sp++; Z80._r.m = 3; }
            public static void POPHL() { Z80._r.l = MMU.rb(Z80._r.sp); Z80._r.sp++; Z80._r.h = MMU.rb(Z80._r.sp); Z80._r.sp++; Z80._r.m = 3; }
            public static void POPAF() { Z80._r.f = MMU.rb(Z80._r.sp); Z80._r.sp++; Z80._r.a = MMU.rb(Z80._r.sp); Z80._r.sp++; Z80._r.m = 3; }

            /*--- Jump ---*/
            public static void JPnn() { Z80._r.pc = MMU.rw(Z80._r.pc); Z80._r.m = 3; }
            public static void JPHL() { Z80._r.pc = (Z80._r.h << 8) + Z80._r.l; Z80._r.m = 1; }
            public static void JPNZnn() { Z80._r.m = 3; if ((Z80._r.f & 0x80) == 0x00) { Z80._r.pc = MMU.rw(Z80._r.pc); Z80._r.m++; } else Z80._r.pc += 2; }
            public static void JPZnn() { Z80._r.m = 3; if ((Z80._r.f & 0x80) == 0x80) { Z80._r.pc = MMU.rw(Z80._r.pc); Z80._r.m++; } else Z80._r.pc += 2; }
            public static void JPNCnn() { Z80._r.m = 3; if ((Z80._r.f & 0x10) == 0x00) { Z80._r.pc = MMU.rw(Z80._r.pc); Z80._r.m++; } else Z80._r.pc += 2; }
            public static void JPCnn() { Z80._r.m = 3; if ((Z80._r.f & 0x10) == 0x10) { Z80._r.pc = MMU.rw(Z80._r.pc); Z80._r.m++; } else Z80._r.pc += 2; }

            public static void JRn() { var i = MMU.rb(Z80._r.pc); if (i > 127) i = -((~i + 1) & 255); Z80._r.pc++; Z80._r.m = 2; Z80._r.pc += i; Z80._r.m++; }
            public static void JRNZn() { var i = MMU.rb(Z80._r.pc); if (i > 127) i = -((~i + 1) & 255); Z80._r.pc++; Z80._r.m = 2; if ((Z80._r.f & 0x80) == 0x00) { Z80._r.pc += i; Z80._r.m++; } }
            public static void JRZn() { var i = MMU.rb(Z80._r.pc); if (i > 127) i = -((~i + 1) & 255); Z80._r.pc++; Z80._r.m = 2; if ((Z80._r.f & 0x80) == 0x80) { Z80._r.pc += i; Z80._r.m++; } }
            public static void JRNCn() { var i = MMU.rb(Z80._r.pc); if (i > 127) i = -((~i + 1) & 255); Z80._r.pc++; Z80._r.m = 2; if ((Z80._r.f & 0x10) == 0x00) { Z80._r.pc += i; Z80._r.m++; } }
            public static void JRCn() { var i = MMU.rb(Z80._r.pc); if (i > 127) i = -((~i + 1) & 255); Z80._r.pc++; Z80._r.m = 2; if ((Z80._r.f & 0x10) == 0x10) { Z80._r.pc += i; Z80._r.m++; } }

            public static void DJNZn() { var i = MMU.rb(Z80._r.pc); if (i > 127) i = -((~i + 1) & 255); Z80._r.pc++; Z80._r.m = 2; Z80._r.b--; if ((Z80._r.b) != 0) { Z80._r.pc += i; Z80._r.m++; } }

            public static void CALLnn() { Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc + 2); Z80._r.pc = MMU.rw(Z80._r.pc); Z80._r.m = 5; }
            public static void CALLNZnn() { Z80._r.m = 3; if ((Z80._r.f & 0x80) == 0x00) { Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc + 2); Z80._r.pc = MMU.rw(Z80._r.pc); Z80._r.m += 2; } else Z80._r.pc += 2; }
            public static void CALLZnn() { Z80._r.m = 3; if ((Z80._r.f & 0x80) == 0x80) { Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc + 2); Z80._r.pc = MMU.rw(Z80._r.pc); Z80._r.m += 2; } else Z80._r.pc += 2; }
            public static void CALLNCnn() { Z80._r.m = 3; if ((Z80._r.f & 0x10) == 0x00) { Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc + 2); Z80._r.pc = MMU.rw(Z80._r.pc); Z80._r.m += 2; } else Z80._r.pc += 2; }
            public static void CALLCnn() { Z80._r.m = 3; if ((Z80._r.f & 0x10) == 0x10) { Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc + 2); Z80._r.pc = MMU.rw(Z80._r.pc); Z80._r.m += 2; } else Z80._r.pc += 2; }

            public static void RET() { Z80._r.pc = MMU.rw(Z80._r.sp); Z80._r.sp += 2; Z80._r.m = 3; }
            public static void RETI() { Z80._r.ime = 1; Z80._ops.rrs(); Z80._r.pc = MMU.rw(Z80._r.sp); Z80._r.sp += 2; Z80._r.m = 3; }
            public static void RETNZ() { Z80._r.m = 1; if ((Z80._r.f & 0x80) == 0x00) { Z80._r.pc = MMU.rw(Z80._r.sp); Z80._r.sp += 2; Z80._r.m += 2; } }
            public static void RETZ() { Z80._r.m = 1; if ((Z80._r.f & 0x80) == 0x80) { Z80._r.pc = MMU.rw(Z80._r.sp); Z80._r.sp += 2; Z80._r.m += 2; } }
            public static void RETNC() { Z80._r.m = 1; if ((Z80._r.f & 0x10) == 0x00) { Z80._r.pc = MMU.rw(Z80._r.sp); Z80._r.sp += 2; Z80._r.m += 2; } }
            public static void RETC() { Z80._r.m = 1; if ((Z80._r.f & 0x10) == 0x10) { Z80._r.pc = MMU.rw(Z80._r.sp); Z80._r.sp += 2; Z80._r.m += 2; } }

            public static void RST00() { Z80._ops.rsv(); Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc); Z80._r.pc = 0x00; Z80._r.m = 3; }
            public static void RST08() { Z80._ops.rsv(); Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc); Z80._r.pc = 0x08; Z80._r.m = 3; }
            public static void RST10() { Z80._ops.rsv(); Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc); Z80._r.pc = 0x10; Z80._r.m = 3; }
            public static void RST18() { Z80._ops.rsv(); Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc); Z80._r.pc = 0x18; Z80._r.m = 3; }
            public static void RST20() { Z80._ops.rsv(); Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc); Z80._r.pc = 0x20; Z80._r.m = 3; }
            public static void RST28() { Z80._ops.rsv(); Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc); Z80._r.pc = 0x28; Z80._r.m = 3; }
            public static void RST30() { Z80._ops.rsv(); Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc); Z80._r.pc = 0x30; Z80._r.m = 3; }
            public static void RST38() { Z80._ops.rsv(); Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc); Z80._r.pc = 0x38; Z80._r.m = 3; }
            public static void RST40() { Z80._ops.rsv(); Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc); Z80._r.pc = 0x40; Z80._r.m = 3; }
            public static void RST48() { Z80._ops.rsv(); Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc); Z80._r.pc = 0x48; Z80._r.m = 3; }
            public static void RST50() { Z80._ops.rsv(); Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc); Z80._r.pc = 0x50; Z80._r.m = 3; }
            public static void RST58() { Z80._ops.rsv(); Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc); Z80._r.pc = 0x58; Z80._r.m = 3; }
            public static void RST60() { Z80._ops.rsv(); Z80._r.sp -= 2; MMU.ww(Z80._r.sp, Z80._r.pc); Z80._r.pc = 0x60; Z80._r.m = 3; }

            public static void NOP() { Z80._r.m = 1; }
            public static void HALT() { Z80._halt = true; Z80._r.m = 1; }

            public static void DI() { Z80._r.ime = 0; Z80._r.m = 1; }
            public static void EI() { Z80._r.ime = 1; Z80._r.m = 1; }
        

            /*--- Helper functions ---*/
            public static void rsv()
            {
                Z80._rsv.a = Z80._r.a; Z80._rsv.b = Z80._r.b;
                Z80._rsv.c = Z80._r.c; Z80._rsv.d = Z80._r.d;
                Z80._rsv.e = Z80._r.e; Z80._rsv.f = Z80._r.f;
                Z80._rsv.h = Z80._r.h; Z80._rsv.l = Z80._r.l;

            }

		    public static void rrs() 
		    {
			    Z80._r.a = Z80._rsv.a; Z80._r.b = Z80._rsv.b;
			    Z80._r.c = Z80._rsv.c; Z80._r.d = Z80._rsv.d;
			    Z80._r.e = Z80._rsv.e; Z80._r.f = Z80._rsv.f;
			    Z80._r.h = Z80._rsv.h; Z80._r.l = Z80._rsv.l;
		    }

		    public static void MAPcb() {
			    var i=MMU.rb(Z80._r.pc); Z80._r.pc++;
			    Z80._r.pc &= 65535;
			    if(Z80._cbmap[i] != null) Z80._cbmap[i]();
			    else Console.WriteLine(i);
		    }

		    public static void XX() {
			    /*Undefined map entry*/
			    var opc = Z80._r.pc-1;
			    //LOG.out('Z80', 'Unimplemented instruction at $'+opc.toString(16)+', stopping.');
			    Z80._stop = true;
		    }
        }
        #endregion

        public static Action[] _map = new Action[] {
          // 00
          Z80._ops.NOP, Z80._ops.LDBCnn, Z80._ops.LDBCmA, Z80._ops.INCBC,
          Z80._ops.INCr_b, Z80._ops.DECr_b, Z80._ops.LDrn_b, Z80._ops.RLCA,
          Z80._ops.LDmmSP, Z80._ops.ADDHLBC, Z80._ops.LDABCm, Z80._ops.DECBC,
          Z80._ops.INCr_c, Z80._ops.DECr_c, Z80._ops.LDrn_c, Z80._ops.RRCA,
          // 10
          Z80._ops.DJNZn, Z80._ops.LDDEnn, Z80._ops.LDDEmA, Z80._ops.INCDE,
          Z80._ops.INCr_d, Z80._ops.DECr_d, Z80._ops.LDrn_d, Z80._ops.RLA,
          Z80._ops.JRn, Z80._ops.ADDHLDE, Z80._ops.LDADEm, Z80._ops.DECDE,
          Z80._ops.INCr_e, Z80._ops.DECr_e, Z80._ops.LDrn_e, Z80._ops.RRA,
          // 20
          Z80._ops.JRNZn, Z80._ops.LDHLnn, Z80._ops.LDHLIA, Z80._ops.INCHL,
          Z80._ops.INCr_h, Z80._ops.DECr_h, Z80._ops.LDrn_h, Z80._ops.DAA,
          Z80._ops.JRZn, Z80._ops.ADDHLHL, Z80._ops.LDAHLI, Z80._ops.DECHL,
          Z80._ops.INCr_l, Z80._ops.DECr_l, Z80._ops.LDrn_l, Z80._ops.CPL,
          // 30
          Z80._ops.JRNCn, Z80._ops.LDSPnn, Z80._ops.LDHLDA, Z80._ops.INCSP,
          Z80._ops.INCHLm, Z80._ops.DECHLm, Z80._ops.LDHLmn, Z80._ops.SCF,
          Z80._ops.JRCn, Z80._ops.ADDHLSP, Z80._ops.LDAHLD, Z80._ops.DECSP,
          Z80._ops.INCr_a, Z80._ops.DECr_a, Z80._ops.LDrn_a, Z80._ops.CCF,
          // 40
          Z80._ops.LDrr_bb, Z80._ops.LDrr_bc, Z80._ops.LDrr_bd, Z80._ops.LDrr_be,
          Z80._ops.LDrr_bh, Z80._ops.LDrr_bl, Z80._ops.LDrHLm_b, Z80._ops.LDrr_ba,
          Z80._ops.LDrr_cb, Z80._ops.LDrr_cc, Z80._ops.LDrr_cd, Z80._ops.LDrr_ce,
          Z80._ops.LDrr_ch, Z80._ops.LDrr_cl, Z80._ops.LDrHLm_c, Z80._ops.LDrr_ca,
          // 50
          Z80._ops.LDrr_db, Z80._ops.LDrr_dc, Z80._ops.LDrr_dd, Z80._ops.LDrr_de,
          Z80._ops.LDrr_dh, Z80._ops.LDrr_dl, Z80._ops.LDrHLm_d, Z80._ops.LDrr_da,
          Z80._ops.LDrr_eb, Z80._ops.LDrr_ec, Z80._ops.LDrr_ed, Z80._ops.LDrr_ee,
          Z80._ops.LDrr_eh, Z80._ops.LDrr_el, Z80._ops.LDrHLm_e, Z80._ops.LDrr_ea,
          // 60
          Z80._ops.LDrr_hb, Z80._ops.LDrr_hc, Z80._ops.LDrr_hd, Z80._ops.LDrr_he,
          Z80._ops.LDrr_hh, Z80._ops.LDrr_hl, Z80._ops.LDrHLm_h, Z80._ops.LDrr_ha,
          Z80._ops.LDrr_lb, Z80._ops.LDrr_lc, Z80._ops.LDrr_ld, Z80._ops.LDrr_le,
          Z80._ops.LDrr_lh, Z80._ops.LDrr_ll, Z80._ops.LDrHLm_l, Z80._ops.LDrr_la,
          // 70
          Z80._ops.LDHLmr_b, Z80._ops.LDHLmr_c, Z80._ops.LDHLmr_d, Z80._ops.LDHLmr_e,
          Z80._ops.LDHLmr_h, Z80._ops.LDHLmr_l, Z80._ops.HALT, Z80._ops.LDHLmr_a,
          Z80._ops.LDrr_ab, Z80._ops.LDrr_ac, Z80._ops.LDrr_ad, Z80._ops.LDrr_ae,
          Z80._ops.LDrr_ah, Z80._ops.LDrr_al, Z80._ops.LDrHLm_a, Z80._ops.LDrr_aa,
          // 80
          Z80._ops.ADDr_b, Z80._ops.ADDr_c, Z80._ops.ADDr_d, Z80._ops.ADDr_e,
          Z80._ops.ADDr_h, Z80._ops.ADDr_l, Z80._ops.ADDHL, Z80._ops.ADDr_a,
          Z80._ops.ADCr_b, Z80._ops.ADCr_c, Z80._ops.ADCr_d, Z80._ops.ADCr_e,
          Z80._ops.ADCr_h, Z80._ops.ADCr_l, Z80._ops.ADCHL, Z80._ops.ADCr_a,
          // 90
          Z80._ops.SUBr_b, Z80._ops.SUBr_c, Z80._ops.SUBr_d, Z80._ops.SUBr_e,
          Z80._ops.SUBr_h, Z80._ops.SUBr_l, Z80._ops.SUBHL, Z80._ops.SUBr_a,
          Z80._ops.SBCr_b, Z80._ops.SBCr_c, Z80._ops.SBCr_d, Z80._ops.SBCr_e,
          Z80._ops.SBCr_h, Z80._ops.SBCr_l, Z80._ops.SBCHL, Z80._ops.SBCr_a,
          // A0
          Z80._ops.ANDr_b, Z80._ops.ANDr_c, Z80._ops.ANDr_d, Z80._ops.ANDr_e,
          Z80._ops.ANDr_h, Z80._ops.ANDr_l, Z80._ops.ANDHL, Z80._ops.ANDr_a,
          Z80._ops.XORr_b, Z80._ops.XORr_c, Z80._ops.XORr_d, Z80._ops.XORr_e,
          Z80._ops.XORr_h, Z80._ops.XORr_l, Z80._ops.XORHL, Z80._ops.XORr_a,
          // B0
          Z80._ops.ORr_b, Z80._ops.ORr_c, Z80._ops.ORr_d, Z80._ops.ORr_e,
          Z80._ops.ORr_h, Z80._ops.ORr_l, Z80._ops.ORHL, Z80._ops.ORr_a,
          Z80._ops.CPr_b, Z80._ops.CPr_c, Z80._ops.CPr_d, Z80._ops.CPr_e,
          Z80._ops.CPr_h, Z80._ops.CPr_l, Z80._ops.CPHL, Z80._ops.CPr_a,
          // C0
          Z80._ops.RETNZ, Z80._ops.POPBC, Z80._ops.JPNZnn, Z80._ops.JPnn,
          Z80._ops.CALLNZnn, Z80._ops.PUSHBC, Z80._ops.ADDn, Z80._ops.RST00,
          Z80._ops.RETZ, Z80._ops.RET, Z80._ops.JPZnn, Z80._ops.MAPcb,
          Z80._ops.CALLZnn, Z80._ops.CALLnn, Z80._ops.ADCn, Z80._ops.RST08,
          // D0
          Z80._ops.RETNC, Z80._ops.POPDE, Z80._ops.JPNCnn, Z80._ops.XX,
          Z80._ops.CALLNCnn, Z80._ops.PUSHDE, Z80._ops.SUBn, Z80._ops.RST10,
          Z80._ops.RETC, Z80._ops.RETI, Z80._ops.JPCnn, Z80._ops.XX,
          Z80._ops.CALLCnn, Z80._ops.XX, Z80._ops.SBCn, Z80._ops.RST18,
          // E0
          Z80._ops.LDIOnA, Z80._ops.POPHL, Z80._ops.LDIOCA, Z80._ops.XX,
          Z80._ops.XX, Z80._ops.PUSHHL, Z80._ops.ANDn, Z80._ops.RST20,
          Z80._ops.ADDSPn, Z80._ops.JPHL, Z80._ops.LDmmA, Z80._ops.XX,
          Z80._ops.XX, Z80._ops.XX, Z80._ops.XORn, Z80._ops.RST28,
          // F0
          Z80._ops.LDAIOn, Z80._ops.POPAF, Z80._ops.LDAIOC, Z80._ops.DI,
          Z80._ops.XX, Z80._ops.PUSHAF, Z80._ops.ORn, Z80._ops.RST30,
          Z80._ops.LDHLSPn, Z80._ops.XX, Z80._ops.LDAmm, Z80._ops.EI,
          Z80._ops.XX, Z80._ops.XX, Z80._ops.CPn, Z80._ops.RST38
        };

    public static Action[] _cbmap = new Action[]
    {
			// CB00
			Z80._ops.RLCr_b, Z80._ops.RLCr_c, Z80._ops.RLCr_d, Z80._ops.RLCr_e,
            Z80._ops.RLCr_h, Z80._ops.RLCr_l, Z80._ops.RLCHL, Z80._ops.RLCr_a,
            Z80._ops.RRCr_b, Z80._ops.RRCr_c, Z80._ops.RRCr_d, Z80._ops.RRCr_e,
            Z80._ops.RRCr_h, Z80._ops.RRCr_l, Z80._ops.RRCHL, Z80._ops.RRCr_a,
			// CB10
			Z80._ops.RLr_b, Z80._ops.RLr_c, Z80._ops.RLr_d, Z80._ops.RLr_e,
            Z80._ops.RLr_h, Z80._ops.RLr_l, Z80._ops.RLHL, Z80._ops.RLr_a,
            Z80._ops.RRr_b, Z80._ops.RRr_c, Z80._ops.RRr_d, Z80._ops.RRr_e,
            Z80._ops.RRr_h, Z80._ops.RRr_l, Z80._ops.RRHL, Z80._ops.RRr_a,
			// CB20
			Z80._ops.SLAr_b, Z80._ops.SLAr_c, Z80._ops.SLAr_d, Z80._ops.SLAr_e,
            Z80._ops.SLAr_h, Z80._ops.SLAr_l, Z80._ops.XX, Z80._ops.SLAr_a,
            Z80._ops.SRAr_b, Z80._ops.SRAr_c, Z80._ops.SRAr_d, Z80._ops.SRAr_e,
            Z80._ops.SRAr_h, Z80._ops.SRAr_l, Z80._ops.XX, Z80._ops.SRAr_a,
			// CB30
			Z80._ops.SWAPr_b, Z80._ops.SWAPr_c, Z80._ops.SWAPr_d, Z80._ops.SWAPr_e,
            Z80._ops.SWAPr_h, Z80._ops.SWAPr_l, Z80._ops.XX, Z80._ops.SWAPr_a,
            Z80._ops.SRLr_b, Z80._ops.SRLr_c, Z80._ops.SRLr_d, Z80._ops.SRLr_e,
            Z80._ops.SRLr_h, Z80._ops.SRLr_l, Z80._ops.XX, Z80._ops.SRLr_a,
			// CB40
			Z80._ops.BIT0b, Z80._ops.BIT0c, Z80._ops.BIT0d, Z80._ops.BIT0e,
            Z80._ops.BIT0h, Z80._ops.BIT0l, Z80._ops.BIT0m, Z80._ops.BIT0a,
            Z80._ops.BIT1b, Z80._ops.BIT1c, Z80._ops.BIT1d, Z80._ops.BIT1e,
            Z80._ops.BIT1h, Z80._ops.BIT1l, Z80._ops.BIT1m, Z80._ops.BIT1a,
			// CB50
			Z80._ops.BIT2b, Z80._ops.BIT2c, Z80._ops.BIT2d, Z80._ops.BIT2e,
            Z80._ops.BIT2h, Z80._ops.BIT2l, Z80._ops.BIT2m, Z80._ops.BIT2a,
            Z80._ops.BIT3b, Z80._ops.BIT3c, Z80._ops.BIT3d, Z80._ops.BIT3e,
            Z80._ops.BIT3h, Z80._ops.BIT3l, Z80._ops.BIT3m, Z80._ops.BIT3a,
			// CB60
			Z80._ops.BIT4b, Z80._ops.BIT4c, Z80._ops.BIT4d, Z80._ops.BIT4e,
            Z80._ops.BIT4h, Z80._ops.BIT4l, Z80._ops.BIT4m, Z80._ops.BIT4a,
            Z80._ops.BIT5b, Z80._ops.BIT5c, Z80._ops.BIT5d, Z80._ops.BIT5e,
            Z80._ops.BIT5h, Z80._ops.BIT5l, Z80._ops.BIT5m, Z80._ops.BIT5a,
			// CB70
			Z80._ops.BIT6b, Z80._ops.BIT6c, Z80._ops.BIT6d, Z80._ops.BIT6e,
            Z80._ops.BIT6h, Z80._ops.BIT6l, Z80._ops.BIT6m, Z80._ops.BIT6a,
            Z80._ops.BIT7b, Z80._ops.BIT7c, Z80._ops.BIT7d, Z80._ops.BIT7e,
            Z80._ops.BIT7h, Z80._ops.BIT7l, Z80._ops.BIT7m, Z80._ops.BIT7a,
			// CB80
			Z80._ops.RES0b, Z80._ops.RES0c, Z80._ops.RES0d, Z80._ops.RES0e,
            Z80._ops.RES0h, Z80._ops.RES0l, Z80._ops.RES0m, Z80._ops.RES0a,
            Z80._ops.RES1b, Z80._ops.RES1c, Z80._ops.RES1d, Z80._ops.RES1e,
            Z80._ops.RES1h, Z80._ops.RES1l, Z80._ops.RES1m, Z80._ops.RES1a,
			// CB90
			Z80._ops.RES2b, Z80._ops.RES2c, Z80._ops.RES2d, Z80._ops.RES2e,
            Z80._ops.RES2h, Z80._ops.RES2l, Z80._ops.RES2m, Z80._ops.RES2a,
            Z80._ops.RES3b, Z80._ops.RES3c, Z80._ops.RES3d, Z80._ops.RES3e,
            Z80._ops.RES3h, Z80._ops.RES3l, Z80._ops.RES3m, Z80._ops.RES3a,
			// CBA0
			Z80._ops.RES4b, Z80._ops.RES4c, Z80._ops.RES4d, Z80._ops.RES4e,
            Z80._ops.RES4h, Z80._ops.RES4l, Z80._ops.RES4m, Z80._ops.RES4a,
            Z80._ops.RES5b, Z80._ops.RES5c, Z80._ops.RES5d, Z80._ops.RES5e,
            Z80._ops.RES5h, Z80._ops.RES5l, Z80._ops.RES5m, Z80._ops.RES5a,
			// CBB0
			Z80._ops.RES6b, Z80._ops.RES6c, Z80._ops.RES6d, Z80._ops.RES6e,
            Z80._ops.RES6h, Z80._ops.RES6l, Z80._ops.RES6m, Z80._ops.RES6a,
            Z80._ops.RES7b, Z80._ops.RES7c, Z80._ops.RES7d, Z80._ops.RES7e,
            Z80._ops.RES7h, Z80._ops.RES7l, Z80._ops.RES7m, Z80._ops.RES7a,
			// CBC0
			Z80._ops.SET0b, Z80._ops.SET0c, Z80._ops.SET0d, Z80._ops.SET0e,
            Z80._ops.SET0h, Z80._ops.SET0l, Z80._ops.SET0m, Z80._ops.SET0a,
            Z80._ops.SET1b, Z80._ops.SET1c, Z80._ops.SET1d, Z80._ops.SET1e,
            Z80._ops.SET1h, Z80._ops.SET1l, Z80._ops.SET1m, Z80._ops.SET1a,
			// CBD0
			Z80._ops.SET2b, Z80._ops.SET2c, Z80._ops.SET2d, Z80._ops.SET2e,
            Z80._ops.SET2h, Z80._ops.SET2l, Z80._ops.SET2m, Z80._ops.SET2a,
            Z80._ops.SET3b, Z80._ops.SET3c, Z80._ops.SET3d, Z80._ops.SET3e,
            Z80._ops.SET3h, Z80._ops.SET3l, Z80._ops.SET3m, Z80._ops.SET3a,
			// CBE0
			Z80._ops.SET4b, Z80._ops.SET4c, Z80._ops.SET4d, Z80._ops.SET4e,
            Z80._ops.SET4h, Z80._ops.SET4l, Z80._ops.SET4m, Z80._ops.SET4a,
            Z80._ops.SET5b, Z80._ops.SET5c, Z80._ops.SET5d, Z80._ops.SET5e,
            Z80._ops.SET5h, Z80._ops.SET5l, Z80._ops.SET5m, Z80._ops.SET5a,
			// CBF0
			Z80._ops.SET6b, Z80._ops.SET6c, Z80._ops.SET6d, Z80._ops.SET6e,
            Z80._ops.SET6h, Z80._ops.SET6l, Z80._ops.SET6m, Z80._ops.SET6a,
            Z80._ops.SET7b, Z80._ops.SET7c, Z80._ops.SET7d, Z80._ops.SET7e,
            Z80._ops.SET7h, Z80._ops.SET7l, Z80._ops.SET7m, Z80._ops.SET7a,
        };
    }
}
